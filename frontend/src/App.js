import React from 'react';
import {Routes} from './routes';
import {BrowserRouter as Router} from 'react-router-dom';
import {SnackbarProvider} from 'notistack';

const App = () => {
	return (
		<Router>
			<SnackbarProvider maxSnack={3}>
				<Routes />
			</SnackbarProvider>
		</Router>
	);
};

export default App;
