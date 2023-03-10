import React, { useState, useEffect } from 'react';
import { Modal, Button, Row, Col, Form } from 'react-bootstrap';
import { addExpenditure, getExpenditureCategories } from "../../services/ExpenditureService";
import { addIncome, getIncomeCategories } from "../../services/IncomeService";
import { useUserContext } from "../../context/UserContext";

export function AddTransactionModal({ show, onHide, transactionType }) {
    const [validationPrice, setValidationPrice] = useState();
    const [validationCategoryId, setValidationCategoryId] = useState();
    const { user } = useUserContext();
    const [categories, setCategories] = useState([]);
    const [dateFrom] = useState("")
    const [dateTo] = useState("")

    function GetCategories() {
        if (transactionType === "expenditure") {
            getExpenditureCategories(user.token, dateFrom, dateTo)
                .then(categories => setCategories(categories));
        }
        else if (transactionType === "income") {
            getIncomeCategories(user.token, dateFrom, dateTo)
                .then(categories => setCategories(categories));
        }
    };
    useEffect(() => {
        GetCategories();
    }, [])

    function handleSubmit(event) {
        event.preventDefault();
        if (transactionType === "expenditure") {
            addExpenditure(event.target.price.value, event.target.date.value, event.target.comment.value, event.target.categoryId.value, user.token)
                .then((result) => {
                    validation(result.errors)
                },
                )
        }
        else if (transactionType === "income") {
            addIncome(event.target.price.value, event.target.date.value, event.target.comment.value, event.target.categoryId.value, user.token)
                .then((result) => {
                    validation(result.errors)
                },
                )
        }

    }
    function validation(e) {
        e.Price !== undefined ? setValidationPrice(e.Price[0]) : setValidationPrice()
        e.CategoryId !== undefined ? setValidationCategoryId(e.CategoryId[0]) : setValidationCategoryId()

    };



    return (
        <Modal show={show} onHide={onHide}
            size="lg"
            aria-labelledby="contained-modal-title-vcenter"
            centered
        >
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">
                    Add New Transaction
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>

                <div className="container">
                    <Row>
                        <Col sm={6}>
                            <Form onSubmit={handleSubmit}>
                                <Form.Group controlId="price">
                                    <Form.Label>price</Form.Label>
                                    <Form.Control
                                        type="number"
                                        step={0.01}
                                        name="price"
                                        placeholder="price"
                                    />
                                    <p class="text-danger">{validationPrice}</p>
                                </Form.Group>
                                <Form.Group controlId="date">
                                    <Form.Label>date</Form.Label>
                                    <Form.Control
                                        type="date"
                                        name="date"
                                    />
                                </Form.Group>

                                <Form.Group controlId="comment">
                                    <Form.Label>comment</Form.Label>
                                    <Form.Control
                                        type="text"
                                        name="comment"
                                        placeholder="comment"
                                    />
                                </Form.Group>

                                <Form.Group controlId="categoryId">
                                    <Form.Label>categoryId</Form.Label>

                                    <Form.Control as="select">
                                        <option value={0} hidden>Select Category </option>
                                        {categories.map(category =>
                                            <option key={category.id} value={category.id}>{category.name}</option>
                                        )}
                                    </Form.Control>
                                    <p class="text-danger">{validationCategoryId}</p>
                                </Form.Group>

                                <Form.Group>
                                    <Button variant="primary" type="submit">
                                        Add Transaction
                                    </Button>
                                </Form.Group>
                            </Form>
                        </Col>
                    </Row>
                </div>


            </Modal.Body>
            <Modal.Footer>
                <Button variant="danger" onClick={onHide}>Close</Button>
            </Modal.Footer>
        </Modal>
    )
}