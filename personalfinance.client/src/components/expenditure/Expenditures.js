import { useState, useEffect} from "react";
import { Table } from 'react-bootstrap';
import { NavLink } from 'react-router-dom'
import { Button, ButtonToolbar } from 'react-bootstrap';
import { getCategories, deleteCategory } from "../../services/ExpenditureService";
import { useUserContext } from "../../context/UserContext";
import { AddCategoryModal } from './AddCategoryModal';
import { EditCategoryModal } from './EditCategoryModal';

function Expenditures() {
    const [categories, setCategories] = useState([]);
    const [refreshKey, setRefreshKey] = useState(0);
    const [addModalShow, setAddModalShow] = useState(false)
    const [editModalShow, setEditModalShow] = useState(false)
    const { user } = useUserContext();

    async function GetCategories() {
        await getCategories(user.token)
            .then(categories => setCategories(categories));
    };

    useEffect(() => {
        GetCategories();
    }, [refreshKey, addModalShow, editModalShow])

    function handleDeleteCategory(id){
        deleteCategory(id, user.token);
        setRefreshKey(oldKey => oldKey + 1)
    };
    return (
        <div>
            <ButtonToolbar className="mt-4">
                <Button
                    variant='primary'
                    onClick={() => setAddModalShow(true)}
                >Add Category</Button>

                <AddCategoryModal
                    show={addModalShow}
                    onHide={() => setAddModalShow(false)}
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
                            <td>{category?.expenditures.reduce((sum, expenditure) => sum + expenditure.price, 0)}</td>
                            <td>
                                <ButtonToolbar>
                                    <Button
                                        className="mr-2" variant="info"
                                        onClick={() => setEditModalShow(true)}
                                    >Edit</Button>

                                    <Button className="mr-2"
                                        //to="/ExpenditureList" as={NavLink}
                                        onClick={() => handleDeleteCategory(category.id)}
                                        variant="danger"
                                    >Delete</Button>

                                    <EditCategoryModal
                                        show={editModalShow}
                                        onHide={() => setEditModalShow(false)}
                                        id={category.id}
                                        name={category.name}
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

export default Expenditures