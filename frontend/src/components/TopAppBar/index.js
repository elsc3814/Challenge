import React from 'react';
import {Toolbar, AppBar, makeStyles, ButtonGroup, Button} from '@material-ui/core';
import {useLocation, useHistory} from 'react-router-dom';

const useStyles = makeStyles(theme => ({
	AppBar: {
		backgroundColor: theme.palette.background.dark,
		position: 'fixed',
		boxShadow: 'none',
	},
	AppBar__logo: {
		flexGrow: 1,
	},
	AppBar__logoButton: {
		color: 'white',
	},
}));

const TopAppBar = () => {
	const classes = useStyles();
	const location = useLocation();
	const history = useHistory();

	return (
		<AppBar className={classes['AppBar']}>
			<Toolbar>
				<div className={classes['AppBar__logo']}>
					<Button
						className={classes['AppBar__logoButton']}
						onClick={() => {
							history.push('/submitTask');
						}}
					>
						COGNIZANT CHALLENGE
					</Button>
				</div>
				<ButtonGroup disableElevation variant="contained" color="primary">
					<Button
						onClick={() => {
							history.push('/submitTask');
						}}
						disabled={location.pathname === '/submitTask' || location.pathname === '/'}
					>
						Solve
					</Button>
					<Button
						onClick={() => {
							history.push('/topThree');
						}}
						disabled={location.pathname === '/topThree'}
					>
						Top 3
					</Button>
				</ButtonGroup>
			</Toolbar>
		</AppBar>
	);
};

export default TopAppBar;
