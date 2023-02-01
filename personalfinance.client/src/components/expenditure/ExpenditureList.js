import { useState, useEffect } from "react";
import { Table } from 'react-bootstrap';
import { Button, ButtonToolbar, Form, InputGroup, Row, Col } from 'react-bootstrap';
import { getExpenditures, deleteExpenditure } from "../../services/ExpenditureService";
import { useUserContext } from "../../context/UserContext";
import { AddTransactionModal } from '../transactionModal/AddTransactionModal';
import { EditTransactionModal } from '../transactionModal/EditTransactionModal';
import { getExpenditureCategories } from "../../services/ExpenditureService";

function ExpenditureList() {
    const { user } = useUserContext();
    const [expenditures, setExpenditures] = useState([]);
    const [addModalShow, setAddModalShow] = useState(false)
    const [editModalShow, setEditModalShow] = useState(false)
    const [refreshKey, setRefreshKey] = useState(0);
    const [dateFrom, setDateFrom] = useState("")
    const [dateTo, setDateTo] = useState("")
    const [categoryId, setCategoryId] = useState(0)
    const [categories, setCategories] = useState([]);



    useEffect(() => {
        getExpenditures(user.token, dateFrom, dateTo, categoryId)
            .then(expenditures => setExpenditures(expenditures));
    }, [refreshKey, addModalShow, editModalShow, user.token, dateFrom, dateTo, categoryId])

    useEffect(() => {
        getExpenditureCategories(user.token, "", "")
            .then(categories => setCategories(categories));
    }, [user.token])

    function handleDeleteExpenditure(id) {
        deleteExpenditure(id, user.token);
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