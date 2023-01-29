import { useState, useEffect } from "react";
import { Table } from 'react-bootstrap';
import { NavLink } from 'react-router-dom'
import { Button, ButtonToolbar } from 'react-bootstrap';
import { getIncomeCategories, deleteIncomeCategory } from "../../services/IncomeService";
import { useUserContext } from "../../context/UserContext";
import { AddCategoryModal } from '../categoryModal/AddCategoryModal';
import { EditCategoryModal } from '../categoryModal/EditCategoryModal';
import Chart from '../chart/chart';

function Incomes() {
    const [categories, setCategories] = useState([]);
    const [refreshKey, setRefreshKey] = useState(0);
    const [addModalShow, setAddModalShow] = useState(false)
    const [editModalShow, setEditModalShow] = useState(false)
    const { user } = useUserContext();

    async function GetCategories() {
        await getIncomeCategories(user.token)
            .then(categories => setCategories(categories));
    };

    useEffect(() => {
        GetCategories();
    }, [refreshKey, addModalShow, editModalShow])

    function handleDeleteCategory(id) {
        deleteIncomeCategory(id, user.token);
        setRefreshKey(oldKey => oldKey + 1)
    };
    return (
        <div>
            <ButtonToolbar className="mt-4">
                <Button
                    variant="danger"
                    to="/IncomeList" as={NavLink}
                >show all transactions</Button>
                <Button
                    variant='primary'
                    onClick={() => setAddModalShow(true)}
                >Add Category</Button>

                <AddCategoryModal
                    show={addModalShow}
                    onHide={() => setAddModalShow(false)}
                    categoryType={"income"}
                />

            </ButtonToolbar>
            <Table className="mt-4" striped bordered hover size="sm">
                <thead>
                    <tr>
                        <th>Category</th>
                        <th>Amount</th>
                        <th>Options</th>
                    </tr>
                </thead>
                <tbody>
                    {categories.map(category =>
                        <tr key={category.id}>
                            <td>{category.name}</td>
                            <td>{category?.incomes.reduce((sum, income) => sum + income.price, 0)}</td>
                            <td>
                                <ButtonToolbar>
                                    <Button
                                        className="mr-2" variant="info"
                                        onClick={() => setEditModalShow(true)}
                                    >Edit</Button>

                                    <Button className="mr-2"
                                        onClick={() => handleDeleteCategory(category.id)}
                                        variant="danger"
                                    >Delete</Button>

                                    <EditCategoryModal
                                        show={editModalShow}
                                        onHide={() => setEditModalShow(false)}
                                        id={category.id}
                                        name={category.name}
                                        categoryType={"income"}
                                    />
                                </ButtonToolbar>

                            </td>
                        </tr>
                    )}
                </tbody>
            </Table>
            <div style={{ width: '600px' }}>
                <Chart
                    labels={categories.map(category => category.name)}
                    data={categories.map(category => category?.incomes.reduce((sum, income) => sum + income.price, 0))}
                />
            </div>
        </div>
    )
}

export default Incomes