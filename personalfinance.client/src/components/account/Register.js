import React, { useState } from 'react'
import { Button, Row, Col, Form } from 'react-bootstrap';
import { Link } from 'react-router-dom';

export default function Login() {
    const [validationFirstName, setValidationFirstName] = useState();
    const [validationLastName, setValidationLastName] = useState();
    const [validationEmail, setValidationEmail] = useState();
    const [validationPassword, setValidationPassword] = useState();


    function handleSubmit(event) {
        event.preventDefault();
        fetch('/api/account/register', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                email: event.target.email.value,
                password: event.target.password.value,
                firstName: event.target.firstName.value,
                lastName: event.target.lastName.value,
                roleId: 2
            })
        })
            .then(res => res.json())
            .then((result) => {
                if (result.errors !== undefined) {
                    validation(result.errors)
                }
                else {
                    alert(result)
                    setValidationFirstName()
                    setValidationLastName()
                    setValidationEmail()
                    setValidationPassword()
                }
            })
    };
    function validation(e) {
        e.FirstName !== undefined ? setValidationFirstName(e.FirstName[0]) : setValidationFirstName()
        e.LastName !== undefined ? setValidationLastName(e.LastName[0]) : setValidationLastName()
        e.Email !== undefined ? setValidationEmail(e.Email[0]) : setValidationEmail()
        e.Password !== undefined ? setValidationPassword(e.Password[0]) : setValidationPassword()

    };

    return (
        <div className="container">
            <h2 className="m-3 d-flex">
                Register
            </h2>
            <Row>
                <Col sm={6}>
                    <Form onSubmit={handleSubmit}>

                        <Form.Group controlId="email">
                            <Form.Label>email</Form.Label>
                            <Form.Control
                                type="text"
                                name="email"
                                placeholder="email"
                            />
                            <p class="text-danger">{validationEmail}</p>
                        </Form.Group>

                        <Form.Group controlId="password">
                            <Form.Label>password</Form.Label>
                            <Form.Control
                                type="password"
                                name="password"
                                placeholder="password"
                            />
                            <p class="text-danger">{validationPassword}</p>
                        </Form.Group>

                        <Form.Group controlId="firstName">
                            <Form.Label>firstName</Form.Label>
                            <Form.Control
                                type="text"
                                name="firstName"
                                placeholder="firstName"
                            />
                            <p class="text-danger">{validationFirstName}</p>
                        </Form.Group>

                        <Form.Group controlId="lastName">
                            <Form.Label>lastName</Form.Label>
                            <Form.Control
                                type="text"
                                name="lastName"
                                placeholder="lastName"
                            />
                            <p class="text-danger">{validationLastName}</p>
                        </Form.Group>

                        <Form.Group>
                            <Button variant="primary" type="submit">
                                Register
                            </Button>
                        </Form.Group>

                        <Form.Group>
                            <Link to='/login'>
                                {"Already have an account? Sign In"}
                            </Link>
                        </Form.Group>
                    </Form>
                </Col>
            </Row>
        </div>
    );
}