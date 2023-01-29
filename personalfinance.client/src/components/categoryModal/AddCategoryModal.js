import React, { useState } from 'react'
import { Modal, Button, Row, Col, Form } from 'react-bootstrap';
import { addExpenditureCategory } from "../../services/ExpenditureService";
import { addIncomeCategory } from "../../services/IncomeService";
import { useUserContext } from "../../context/UserContext";

export function AddCategoryModal({ show, onHide, categoryType}) {
    const [validationName, setValidationName] = useState();
    const { user } = useUserContext();

    function handleSubmit(event) {
        event.preventDefault();
        if (categoryType === "expenditure")
        {
            addExpenditureCategory(event.target.name.value, user.token)
                .then((result) => {
                    validation(result.errors)
                },
                )
        }
        else if(categoryType === "income") {
            addIncomeCategory(event.target.name.value, user.token)
                .then((result) => {
                    validation(result.errors)
                },
                )
        }

    }
    function validation(e) {
        e.Name !== undefined ? setValidationName(e.Name[0]) : setValidationName()

    };



        return (
            <Modal show={show} onHide={onHide}
                size="lg"
                aria-labelledby="contained-modal-title-vcenter"
                centered
            >
                <Modal.Header closeButton>
                    <Modal.Title id="contained-modal-title-vcenter">
                        Add New Category
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body>

                    <div className="container">
                        <Row>
                            <Col sm={6}>
                                <Form onSubmit={handleSubmit}>
                                    <Form.Group controlId="name">
                                        <Form.Label>name</Form.Label>
                                        <Form.Control
                                            type="text"
                                            name="name"
                                            placeholder="name"
                                        />
                                        <p class="text-danger">{validationName}</p>
                                    </Form.Group>

                                    <Form.Group>
                                        <Button variant="primary" type="submit">
                                            Add Category
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