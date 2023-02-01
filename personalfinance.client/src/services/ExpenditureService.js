export async function getExpenditures(token, dateFrom, dateTo, categoryId) {
    return await fetch(`/api/expenditure?dateFrom=${dateFrom}&dateTo=${dateTo}&categoryId=${categoryId}`, {
        method: "GET",
        headers: {
            'Authorization': 'Bearer ' + token,
            'Content-Type': 'application/json'
        },
    })
        .then(res => res.json())
}

export async function deleteExpenditure(id, token) {
    return await fetch(`/api/expenditure/${id}`, {
        method: 'DELETE',
        headers: {
            'Authorization': 'Bearer ' + token,
            'Content-Type': 'application/json'
        },
    })
        .then(res => res.text())
}

export async function addExpenditure(price, date, comment, categoryId, token) {
    return await fetch(`/api/expenditure`, {
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
export async function updateExpenditure(id, price, date, comment, categoryId, token) {
    return await fetch(`/api/expenditure/` + id, {
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

export async function getExpenditureCategories(token, dateFrom, dateTo) {
    return await fetch(`/api/expenditureCategory?dateFrom=${dateFrom}&dateTo=${dateTo}`, {
        method: "GET",
        headers: {
            'Authorization': 'Bearer ' + token,
            'Content-Type': 'application/json'
        },
    })
        .then(res => res.json())
}

export async function deleteExpenditureCategory(id, token) {
    return await fetch(`/api/expenditureCategory/${id}`, {
        method: 'DELETE',
        headers: {
            'Authorization': 'Bearer ' + token,
            'Content-Type': 'application/json'
        },
    })
        .then(res => res.text())
}

export async function addExpenditureCategory(name, token) {
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
export async function updateExpenditureCategory(id, name, token) {
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