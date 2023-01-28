import React from 'react';
import './App.css';

import Home from './components/home/Home'
import Login from './components/account/Login'
import Register from './components/account/Register'
import Expenditures from './components/expenditure/Expenditures'
import ExpenditureList from './components/expenditure/ExpenditureList'
import Incomes from './components/income/Incomes'

import { Route, Routes, NavLink } from 'react-router-dom'
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { useUserContext } from "./context/UserContext";

function App() {

    const { user, setUser } = useUserContext();

    return (
            <div className="container">

                <h2 className="m-3 d-flex justify-content-center">
                    Personal Finance App
                </h2>
            {user &&
                <h2 className="m-3 d-flex justify-content-center">
                {user.email}
                </h2>
            }
                <Navbar bg="dark" variant="dark">
                    <Container>
                    <Navbar.Brand to="/Home" as={NavLink}>PersonalFinanceApp</Navbar.Brand>
                        
                        <Nav className="justify-content-end flex-grow-1 pe-3">
                        <Nav.Link to="/Home" as={NavLink}>Home</Nav.Link>
                        {!user &&
                            <>
                            <Nav.Link to="/Login" as={NavLink}>Login</Nav.Link>
                            <Nav.Link to="/Register" as={NavLink}>Register</Nav.Link>
                            </>
                        }
                        {user &&
                            <>
                            <Nav.Link to="/Expenditures" as={NavLink}>Expenditures</Nav.Link>
                            <Nav.Link to="/Incomes" as={NavLink}>Incomes</Nav.Link>
                            <Nav.Link to="/Home" as={NavLink} onClick={() => { setUser() }}>Logout</Nav.Link>
                            </>
                        }
                            </Nav>
                        
                    </Container>
                </Navbar>

                <Routes>
                    <Route exact path='/Home' element={<Home />} />
                    <Route path='/Login' element={<Login />} />
                    <Route path='/Register' element={<Register />} />
                <Route path='/Expenditures' element={<Expenditures />} />
                    <Route path='/ExpenditureList' element={<ExpenditureList />} />
                    <Route path='/Incomes' element={<Incomes />} />
                </Routes>

            </div>
    );
}

export default App;