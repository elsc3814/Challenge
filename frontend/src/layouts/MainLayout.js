import React from 'react';
import PropTypes from 'prop-types';
import {makeStyles} from '@material-ui/core';
import TopAppBar from '../components/TopAppBar';

const useStyles = makeStyles(() => ({
	MainLayout: {
		display: 'flex',
		height: '100%',
	},
	MainLayout__wrapper: {
		display: 'flex',
		flex: '1 1 auto',
		paddingTop: 64,
	},
	MainLayout__container: {
		display: 'flex',
		flex: '1 1 auto',
	},
	MainLayout__content: {
		flex: '1 1 auto',
		height: '100%',
		padding: '20px',
	},
}));

const MainLayout = ({children}) => {
	const classes = useStyles();

	return (
		<div className={classes['MainLayout']}>
			<TopAppBar />
			<div className={classes['MainLayout__wrapper']}>
				<div className={classes['MainLayout__container']}>
					<div className={classes['MainLayout__content']}>{children}</div>
				</div>
			</div>
		</div>
	);
};

MainLayout.propTypes = {
	children: PropTypes.node,
};

export default MainLayout;
