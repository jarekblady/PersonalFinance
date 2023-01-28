import React, { useState } from 'react'
import { Modal, Button, Row, Col, Form } from 'react-bootstrap';
import { updateCategory } from "../../services/ExpenditureService";
import { useUserContext } from "../../context/UserContext";

export function EditCategoryModal({ show, onHide, id, name }) {
    const [validationName, setValidationName] = useState();
    const { user } = useUserContext();

    function handleSubmit(event) {
        event.preventDefault();
        updateCategory(event.target.id.value, event.target.name.value, user.token)
            .then((result) => {
                validation(result.errors)
            },
        )
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
                    Edit Category
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

                                <Form.Group controlId="name">
                                    <Form.Label>name</Form.Label>
                                    <Form.Control
                                        type="text"
                                        name="name"
                                        defaultValue={name}
                                        placeholder="name"
                                    />
                                    <p class="text-danger">{validationName}</p>
                                </Form.Group>

                                <Form.Group>
                                    <Button variant="primary" type="submit">
                                        Update Category
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