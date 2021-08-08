import React, {useEffect, useState} from 'react';
import {TextField, Grid, Typography, Button, makeStyles} from '@material-ui/core';
import {Autocomplete} from '@material-ui/lab';
import {Formik, Form, Field} from 'formik';
import * as Yup from 'yup';
import {getAllChallenges, submitTask} from '../api/Challenge';
import {useCustomSnackbar} from '../hooks/useCustomSnackbar';

const useStyles = makeStyles(() => {
	const centerHorizontally = {
		display: 'flex',
		justifyContent: 'center',
	};
	return {
		TaskForm: {
			...centerHorizontally,
		},
		TaskForm__grid: {
			maxWidth: 600,
		},
		TaskForm__submit: {
			...centerHorizontally,
		},
	};
});

const validationSchema = Yup.object().shape({
	name: Yup.string().required('Name is required.'),
	script: Yup.string().required('Name is required.'),
	challengeId: Yup.number().required('Challenge not selected'),
});

const SubmitTask = () => {
	const classes = useStyles();
	const [tasks, setTasks] = useState([]);
	const [selectedTask, setSelectedTask] = useState({name: ''});
	const {showSuccess, showError} = useCustomSnackbar();

	useEffect(() => {
		getAllChallenges()
			.then(response => {
				setTasks(response.data);
				setSelectedTask(response.data[0]);
			})
			.catch(error => {
				showError(error.message);
			});
	}, []); // eslint-disable-line react-hooks/exhaustive-deps

	const onTaskChange = task => {
		setSelectedTask(task);
	};

	return (
		<Formik
			initialValues={{
				name: '',
				script: 'using System;\n\nclass Program\n{\n\tstatic void Main(string[] args)\n\t{\n\t}\n}',
				challengeId: 0,
			}}
			validationSchema={validationSchema}
			onSubmit={form => {
				submitTask({...form, challengeId: form.challengeId || selectedTask?.id}).then(
					() => showSuccess('Code was successfully uploaded!'),
					err => showError(err?.response?.data?.message)
				);
			}}
		>
			{({errors, touched, setFieldValue}) => (
				<Form className={classes['TaskForm']}>
					<Grid container spacing={2} className={classes['TaskForm__grid']}>
						<Grid item xs={12}>
							<Field
								as={TextField}
								name="name"
								label="Name"
								variant="outlined"
								size="small"
								fullWidth
								error={errors.name && touched.name}
								helperText={errors.name && touched.name ? errors.name : undefined}
							/>
						</Grid>
						<Grid item xs={12}>
							<Autocomplete
								options={tasks}
								getOptionLabel={option => option.name}
								variant="outlined"
								renderInput={params => (
									<TextField
										{...params}
										label="Select task"
										error={!!errors.challengeId}
										helperText={errors.challengeId ? errors.challengeId : undefined}
									/>
								)}
								size="small"
								onChange={(_, value) => {
									setFieldValue('challengeId', value?.id);
									onTaskChange(value);
								}}
								value={selectedTask}
								getOptionSelected={option => option.id}
							/>
						</Grid>
						<Grid item xs={12}>
							<Typography variant="subtitle1">{selectedTask?.description}</Typography>
						</Grid>
						<Grid item xs={12}>
							<Field
								as={TextField}
								name="script"
								label="Solution code"
								multiline
								rows={12}
								variant="outlined"
								size="small"
								fullWidth
								error={errors.script && touched.script}
								helperText={errors.script && touched.script ? errors.script : undefined}
							/>
						</Grid>
						<Grid item xs={12} className={classes['TaskForm__submit']}>
							<Button variant="contained" color="primary" type="submit">
								Submit
							</Button>
						</Grid>
					</Grid>
				</Form>
			)}
		</Formik>
	);
};

export default SubmitTask;
