import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';

const TopTable = ({rows}) => {
	return (
		<TableContainer component={Paper}>
			<Table aria-label="simple table">
				<TableHead>
					<TableRow>
						<TableCell>Name</TableCell>
						<TableCell>Script</TableCell>
						<TableCell>Cpu time</TableCell>
						<TableCell>Memory</TableCell>
					</TableRow>
				</TableHead>
				<TableBody>
					{rows.map((row, key) => (
						<TableRow key={key}>
							<TableCell component="th" scope="row">
								{row.name}
							</TableCell>
							<TableCell>{row.script}</TableCell>
							<TableCell>{row.cpuTime}</TableCell>
							<TableCell>{row.memory}</TableCell>
						</TableRow>
					))}
				</TableBody>
			</Table>
		</TableContainer>
	);
};

export default TopTable;
