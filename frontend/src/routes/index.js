import React from 'react';
import {Switch, Route} from 'react-router-dom';
import MainLayout from '../layouts/MainLayout';
import SubmitTask from '../pages/SubmitTask';
import TopThree from '../pages/TopThree';

export const Routes = () => (
	<Switch>
		<Route path={'/topThree'} strict={false}>
			<MainLayout>
				<TopThree />
			</MainLayout>
		</Route>
		<Route path={['/submitTask', '/']}>
			<MainLayout>
				<SubmitTask />
			</MainLayout>
		</Route>
	</Switch>
);
