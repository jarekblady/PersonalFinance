import { useState, useEffect } from "react";
import { Table } from 'react-bootstrap';
import { Button, ButtonToolbar } from 'react-bootstrap';
import { getExpenditures, deleteExpenditure } from "../../services/ExpenditureService";
import { useUserContext } from "../../context/UserContext";
import { AddTransactionModal } from '../transactionModal/AddTransactionModal';
import { EditTransactionModal } from '../transactionModal/EditTransactionModal';

function ExpenditureList() {
    const { user } = useUserContext();
    const [expenditures, setExpenditures] = useState([]);
    const [addModalShow, setAddModalShow] = useState(false)
    const [editModalShow, setEditModalShow] = useState(false)
    const [refreshKey, setRefreshKey] = useState(0);

    async function GetExpenditures() {
        await getExpenditures(user.token)
            .then(expenditures => setExpenditures(expenditures));
    };

    useEffect(() => {
        GetExpenditures();
    }, [refreshKey, addModalShow, editModalShow])

    function handleDeleteExpenditure(id) {
        deleteExpenditure(id, user.token);
        setRefreshKey(oldKey => oldKey + 1)
    };

    return (
        <div>
            <ButtonToolbar className="mt-4">
                <Button
                    variant='primary'
                    onClick={() => setAddModalShow(true)}
                >Add Expenditure</Button>

                <AddTransactionModal
                    show={addModalShow}
                    onHide={() => setAddModalShow(false)}
                    transactionType={"expenditure"}
                />

            </ButtonToolbar>
            <Table className="mt-4" striped bordered hover size="sm">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Price</th>
                        <th>Comment</th>
                        <th>Category</th>
                    </tr>
                </thead>
                <tbody>
                    {expenditures.map(expenditure =>
                        <tr key={expenditure.id}>
                            <td>{expenditure.date.split('T')[0]}</td>
                            <td>${(expenditure.price).toFixed(2)}</td>
                            <td>{expenditure.comment}</td>
                            <td>{expenditure.categoryName}</td>
                            <td>
                                <ButtonToolbar>
                                    <Button
                                        className="mr-2" variant="info"
                                        onClick={() => setEditModalShow(true)}
                                    >Edit</Button>

                                    <Button className="mr-2"
                                        onClick={() => handleDeleteExpenditure(expenditure.id)}
                                        variant="danger"
                                    >Delete</Button>

                                    <EditTransactionModal
                                        show={editModalShow}
                                        onHide={() => setEditModalShow(false)}
                                        transactionType={"expenditure"}
                                        id={expenditure.id}
                                        price={expenditure.price}
                                        date={expenditure.date}
                                        comment={expenditure.comment}
                                        categoryId={expenditure.categoryId}
                                    />
                                </ButtonToolbar>

                            </td>
                        </tr>
                    )}
                </tbody>
            </Table>
        </div>
    )
}

export default ExpenditureList