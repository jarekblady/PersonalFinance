import { useState, useEffect } from "react";
import { Table } from 'react-bootstrap';
import { Button, ButtonToolbar, Form, InputGroup, Row, Col } from 'react-bootstrap';
import { getIncomes, deleteIncome } from "../../services/IncomeService";
import { useUserContext } from "../../context/UserContext";
import { AddTransactionModal } from '../transactionModal/AddTransactionModal';
import { EditTransactionModal } from '../transactionModal/EditTransactionModal';
import { getIncomeCategories } from "../../services/IncomeService";

function IncomeList() {
    const { user } = useUserContext();
    const [incomes, setIncomes] = useState([]);
    const [addModalShow, setAddModalShow] = useState(false)
    const [editModalShow, setEditModalShow] = useState(false)
    const [refreshKey, setRefreshKey] = useState(0);
    const [dateFrom, setDateFrom] = useState("")
    const [dateTo, setDateTo] = useState("")
    const [categoryId, setCategoryId] = useState(0)
    const [categories, setCategories] = useState([]);

    useEffect(() => {
        getIncomes(user.token, dateFrom, dateTo, categoryId)
            .then(incomes => setIncomes(incomes));
    }, [refreshKey, addModalShow, editModalShow, user.token, dateFrom, dateTo, categoryId])

    useEffect(() => {
        getIncomeCategories(user.token, "", "")
            .then(categories => setCategories(categories));
    }, [user.token])


    function handleDeleteIncome(id) {
        deleteIncome(id, user.token);
        setRefreshKey(oldKey => oldKey + 1)
    };
    const handleDateFrom = (event) => {
        setDateFrom(event.target.value);
    };
    const handleDateTo = (event) => {
        setDateTo(event.target.value);
    };
    const handleCategoryId = (event) => {
        setCategoryId(event.target.value);
    };

    return (
        <div>
            <Row className="mb-3">
                <InputGroup as={Col} className='mt-3'>
                    <InputGroup.Text>Date From</InputGroup.Text>
                    <Form.Control type="date" required onChange={handleDateFrom} value={dateFrom} />
                </InputGroup>
                <InputGroup as={Col} className='mt-3'>
                    <InputGroup.Text>Date To</InputGroup.Text>
                    <Form.Control type="date" required onChange={handleDateTo} value={dateTo} />
                </InputGroup>
                <InputGroup as={Col} className='mt-3'>
                    <InputGroup.Text>Category</InputGroup.Text>
                    <Form.Select style={{ width: "auto" }}
                        onChange={handleCategoryId}>
                        <option value="0">All Categories</option>
                        {categories.map(category => (
                            <option key={category.id} value={category.id}>{category.name}</option>
                        ))}

                    </Form.Select>
                </InputGroup>
            </Row>

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