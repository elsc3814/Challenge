import React, {useEffect, useState} from 'react';
import {getAllChallenges, getTop3} from '../api/Challenge';
import {useCustomSnackbar} from '../hooks/useCustomSnackbar';
import TopTable from '../components/TopTable';

const TopThree = () => {
	const [top3, setTop3] = useState([]);

	const {showError} = useCustomSnackbar();

	useEffect(() => {
		getAllChallenges().then(challenges => {
			const promises = [];

			for (const challenge of challenges.data) {
				promises.push(
					getTop3(challenge.id).then(
						response => ({...response.data, challenge}),
						error => showError(error.message)
					)
				);
			}

			Promise.all(promises).then(x => setTop3(x));
		});
	}, []); // eslint-disable-line react-hooks/exhaustive-deps

	return (
		<>
			{top3.map(({challenge, byMemory, byCpuTime}, index) => {
				return (
					<div key={index}>
						<h2>{challenge.name}</h2>
						<h3>By cpu time</h3>
						<TopTable rows={byCpuTime} />
						<h3>By memory</h3>
						<TopTable rows={byMemory} />
					</div>
				);
			})}
		</>
	);
};

export default TopThree;
