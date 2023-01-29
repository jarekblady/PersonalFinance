import { useState, useEffect } from "react";
import { Table } from 'react-bootstrap';
import { Button, ButtonToolbar } from 'react-bootstrap';
import { getIncomes, deleteIncome } from "../../services/IncomeService";
import { useUserContext } from "../../context/UserContext";
import { AddTransactionModal } from '../transactionModal/AddTransactionModal';
import { EditTransactionModal } from '../transactionModal/EditTransactionModal';

function IncomeList() {
    const { user } = useUserContext();
    const [incomes, setIncomes] = useState([]);
    const [addModalShow, setAddModalShow] = useState(false)
    const [editModalShow, setEditModalShow] = useState(false)
    const [refreshKey, setRefreshKey] = useState(0);

    useEffect(() => {
        getIncomes(user.token)
            .then(incomes => setIncomes(incomes));
    }, [refreshKey, addModalShow, editModalShow, user.token])

    function handleDeleteIncome(id) {
        deleteIncome(id, user.token);
        setRefreshKey(oldKey => oldKey + 1)
    };

    return (
        <div>
            <ButtonToolbar className="mt-4">
                <Button
                    variant='primary'
                    onClick={() => setAddModalShow(true)}
                >Add Income</Button>

                <AddTransactionModal
                    show={addModalShow}
                    onHide={() => setAddModalShow(false)}
                    transactionType={"income"}
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
                    {incomes.map(income =>
                        <tr key={income.id}>
                            <td>{income.date.split('T')[0]}</td>
                            <td>${(income.price).toFixed(2)}</td>
                            <td>{income.comment}</td>
                            <td>{income.categoryName}</td>
                            <td>
                                <ButtonToolbar>
                                    <Button
                                        className="mr-2" variant="info"
                                        onClick={() => setEditModalShow(true)}
                                    >Edit</Button>

                                    <Button className="mr-2"
                                        onClick={() => handleDeleteIncome(income.id)}
                                        variant="danger"
                                    >Delete</Button>

                                    <EditTransactionModal
                                        show={editModalShow}
                                        onHide={() => setEditModalShow(false)}
                                        transactionType={"income"}
                                        id={income.id}
                                        price={income.price}
                                        date={income.date}
                                        comment={income.comment}
                                        categoryId={income.categoryId}
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

export default IncomeList