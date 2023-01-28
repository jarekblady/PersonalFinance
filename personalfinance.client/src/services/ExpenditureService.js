export async function getCategories(token) {
    return await fetch(`/api/expenditureCategory`, {
        method: "GET",
        headers: {
            'Authorization': 'Bearer ' + token,
            'Content-Type': 'application/json'
        },
    })
        .then(res => res.json())
}

export async function deleteCategory(id, token) {
    return await fetch(`/api/expenditureCategory/${id}`, {
        method: 'DELETE',
        headers: {
            'Authorization': 'Bearer ' + token,
            'Content-Type': 'application/json'
        },
    })
        .then(res => res.text())
}
export async function addCategory(name, token) {
    return await fetch(`/api/expenditureCategory`, {
        method: 'POST',
        headers: {
            'Authorization': 'Bearer ' + token,
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            name: name
        })
    })
        .then(res => res.json())
}
export async function updateCategory(id, name, token) {
    return await fetch(`/api/expenditureCategory/` + id, {
        method: 'PUT',
        headers: {
            'Authorization': 'Bearer ' + token,
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            id: id,
            name: name
        })
    })
        .then(res => res.json())
}