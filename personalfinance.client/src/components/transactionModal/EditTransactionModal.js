import React, { useState, useEffect } from 'react';
import { Modal, Button, Row, Col, Form } from 'react-bootstrap';
import { updateExpenditure, getExpenditureCategories } from "../../services/ExpenditureService";
import { updateIncome, getIncomeCategories } from "../../services/IncomeService";
import { useUserContext } from "../../context/UserContext";

export function EditTransactionModal({ show, onHide, id, price, date, comment, categoryId, transactionType }) {
    const [validationPrice, setValidationPrice] = useState();
    const [validationCategoryId, setValidationCategoryId] = useState();
    const { user } = useUserContext();
    const [categories, setCategories] = useState([]);

    function GetCategories() {
        if (transactionType === "expenditure") {
            getExpenditureCategories(user.token)
                .then(categories => setCategories(categories));
        }
        else if (transactionType === "income") {
            getIncomeCategories(user.token)
                .then(categories => setCategories(categories));
        }
    };
    useEffect(() => {
        GetCategories();
    }, [GetCategories])

    function handleSubmit(event) {
        event.preventDefault();

        if (transactionType === "expenditure") {
            updateExpenditure(event.target.id.value, event.target.price.value, event.target.date.value, event.target.comment.value, event.target.categoryId.value, user.token)
                .then((result) => {
                    validation(result.errors)
                },
                )
        }
        else if (transactionType === "income") {
            updateIncome(event.target.id.value, event.target.price.value, event.target.date.value, event.target.comment.value, event.target.categoryId.value, user.token)
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
                    Edit Transaction
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>

                <div className="container">
                    <Row>
                        <Col sm={6}>
                            <Form onSubmit={handleSubmit}>

                                <Form.Group controlId="id">
                                    <Form.Label>id</Form.Label>
                                    <Form.Control
                                        type="text"
                                        name="id"
                                        disabled
                                        defaultValue={id}
                                        placeholder="id"
                                    />
                                </Form.Group>

                                <Form.Group controlId="price">
                                    <Form.Label>price</Form.Label>
                                    <Form.Control
                                        type="number"
                                        name="price"
                                        defaultValue={price}
                                        placeholder="price"
                                    />
                                    <p class="text-danger">{validationPrice}</p>
                                </Form.Group>

                                <Form.Group controlId="date">
                                    <Form.Label>date</Form.Label>
                                    <Form.Control
                                        type="date"
                                        name="date"
                                        defaultValue={date.split("T")[0]}
                                    />
                                </Form.Group>

                                <Form.Group controlId="comment">
                                    <Form.Label>comment</Form.Label>
                                    <Form.Control
                                        type="text"
                                        name="comment"
                                        defaultValue={comment}
                                        placeholder="comment"
                                    />
                                </Form.Group>

                                <Form.Group controlId="categoryId">
                                    <Form.Label>categoryId</Form.Label>

                                    <Form.Control as="select" defaultValue={categoryId}>
                                        {categories.map(category =>
                                            <option key={category.id} value={category.id}>{category.name}</option>
                                        )}
                                    </Form.Control>
                                    <p class="text-danger">{validationCategoryId}</p>
                                </Form.Group>

                                <Form.Group>
                                    <Button variant="primary" type="submit">
                                        Update Transaction
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