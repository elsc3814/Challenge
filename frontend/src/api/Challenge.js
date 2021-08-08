import axios from 'axios';

const baseURL = 'https://localhost:44311/';

const http = axios.create({
	baseURL,
	headers: {
		Accept: 'application/json',
		'Content-Type': 'application/json',
	},
});

export const getAllChallenges = () => http.get('/challenges');
export const submitTask = task => http.post('/challenges/submitTask', task);
export const getTop3 = challengeId => http.get(`/challenges/${challengeId}/top3`);
