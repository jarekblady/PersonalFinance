export async function getIncomes(token, dateFrom, dateTo, categoryId) {
    return await fetch(`/api/income?dateFrom=${dateFrom}&dateTo=${dateTo}&categoryId=${categoryId}`, {
        method: "GET",
        headers: {
            'Authorization': 'Bearer ' + token,
            'Content-Type': 'application/json'
        },
    })
        .then(res => res.json())
}

export async function deleteIncome(id, token) {
    return await fetch(`/api/income/${id}`, {
        method: 'DELETE',
        headers: {
            'Authorization': 'Bearer ' + token,
            'Content-Type': 'application/json'
        },
    })
        .then(res => res.text())
}

export async function addIncome(price, date, comment, categoryId, token) {
    return await fetch(`/api/income`, {
        method: 'POST',
        headers: {
            'Authorization': 'Bearer ' + token,
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            price: price,
            date: date,
            comment: comment,
            categoryId: categoryId
        })
    })
        .then(res => res.json())
}
export async function updateIncome(id, price, date, comment, categoryId, token) {
    return await fetch(`/api/income/` + id, {
        method: 'PUT',
        headers: {
            'Authorization': 'Bearer ' + token,
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            id: id,
            price: price,
            date: date,
            comment: comment,
            categoryId: categoryId
        })
    })
        .then(res => res.json())
}

export async function getIncomeCategories(token, dateFrom, dateTo) {
    return await fetch(`/api/incomeCategory?dateFrom=${dateFrom}&dateTo=${dateTo}`, {
        method: "GET",
        headers: {
            'Authorization': 'Bearer ' + token,
            'Content-Type': 'application/json'
        },
    })
        .then(res => res.json())
}

export async function deleteIncomeCategory(id, token) {
    return await fetch(`/api/incomeCategory/${id}`, {
        method: 'DELETE',
        headers: {
            'Authorization': 'Bearer ' + token,
            'Content-Type': 'application/json'
        },
    })
        .then(res => res.text())
}
export async function addIncomeCategory(name, token) {
    return await fetch(`/api/incomeCategory`, {
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
export async function updateIncomeCategory(id, name, token) {
    return await fetch(`/api/incomeCategory/` + id, {
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