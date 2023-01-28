import { Table } from 'react-bootstrap';
import { useUserContext } from "../../context/UserContext";

function ExpenditureList() {
    const { expenditures } = useUserContext();
    return (
        <Table className="mt-4" striped bordered hover size="sm">
            <thead>
                <tr>
                    <th>Price</th>
                    <th>Date</th>
                    <th>Comment</th>
                </tr>
            </thead>
            <tbody>
                {expenditures.map(expenditure =>
                    <tr key={expenditure.id}>
                        <td>{expenditure.date.split('T')[0]} {expenditure.date.split('T')[1].split('.')[0]}</td>
                        <td>${(expenditure.price).toFixed(2)}</td>
                        <td>{expenditure.comment}</td>
                    </tr>
                )}
            </tbody>
        </Table>
    )
}

export default ExpenditureList