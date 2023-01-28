import React, { useState } from 'react'
import { Button, Row, Col, Form } from 'react-bootstrap';
import { useUserContext } from "../../context/UserContext";
import { Link } from 'react-router-dom';


export default function Login() {
    const { setUser } = useUserContext();
    const [error, setError] = useState();


    function handleSubmit(event) {
        setUser();
        event.preventDefault();
        fetch('/api/account/login', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                email: event.target.email.value,
                password: event.target.password.value,
            })
        })
            .then(res => {
                if (!res.ok) res.text().then((value) => setError(value))
                else {
                    setError()
                    return res.json()
                }
            })
            .then((result) => {
                setUser(result)
            })
    };



    return (
        <div className="container">
            <h2 className="m-3 d-flex">
                Sign in
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
                        </Form.Group>

                        <Form.Group controlId="password">
                            <Form.Label>password</Form.Label>
                            <Form.Control
                                type="password"
                                name="password"
                                placeholder="password"
                            />
                        </Form.Group>

                        <Form.Group>
                            <Form.Text className="text-danger">
                                {error}
                            </Form.Text>
                        </Form.Group>

                        <Form.Group>
                            <Button variant="primary" type="submit">
                                Sign In
                            </Button>
                        </Form.Group>

                        <Form.Group>                          
                            <Link to='/register'>
                                {"Don't have an account? Sign Up"}
                            </Link>                           
                        </Form.Group>
                    </Form>
                </Col>
            </Row>
        </div>


    );
}