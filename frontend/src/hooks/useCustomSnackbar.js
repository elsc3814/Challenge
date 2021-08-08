import React from 'react';
import {useSnackbar} from 'notistack';
import {Slide} from '@material-ui/core';
import MuiAlert from '@material-ui/lab/Alert';

const Alert = React.forwardRef((props, ref) => <MuiAlert elevation={6} variant="filled" {...props} ref={ref} />);

function transitionLeft(props) {
	return <Slide {...props} direction="right" />;
}

export function useCustomSnackbar() {
	const {enqueueSnackbar, closeSnackbar} = useSnackbar();

	function showSnackbar(text, severity) {
		enqueueSnackbar(text, {
			autoHideDuration: 6000,
			TransitionComponent: transitionLeft,
			content: (key, message) => (
				<Alert
					onClose={() => {
						closeSnackbar(key);
					}}
					severity={severity}
					id={key}
				>
					{message}
				</Alert>
			),
		});
	}

	function showError(text) {
		showSnackbar(text, 'error');
	}

	function showSuccess(text) {
		showSnackbar(text, 'success');
	}

	return {
		showSnackbar,
		showError,
		showSuccess,
	};
}
