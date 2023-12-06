const products = []
let itemCount = 0;
let totalAmount = 0;

const getProductInCart = async () => {
    if (sessionStorage.getItem(`cart`) != null) {
        let c = sessionStorage.getItem(`cart`)
        c = JSON.parse(c)
        for (let i = 0; i < c.length; i++) {
            products.push(c[i])
            await ShowProductInCart(products[i])
        }
        document.getElementById("totalAmount").innerHTML = totalAmount;
        document.getElementById("itemsCount").innerHTML = itemCount;
    }
    return products;
}

const ShowProductInCart = async (product) => {
    let tmp = document.querySelector("#temp-row")
    const clone = tmp.content.cloneNode(true);
    clone.querySelector('.price').innerText = product.price;
    clone.querySelector(".image").src = "/pictures/" + product.image;
    clone.querySelector(".descriptionColumn").innerText = product.productName;
    let btn = clone.querySelector("button");
    btn.addEventListener('click', () => { deleteProduct(product) });
    document.getElementById("tbody").appendChild(clone);
    totalAmount += product.price;
    itemCount++;
}

const deleteProduct = (prod) => {
    let cart = []
    let p = 0
    for (let i = 0; i < products.length; i++) {
        if (products[i].productId != prod.productId)
            cart.push(products[i])
        else {
            p++;
            if (p > 1)
                cart.push(products[i])
        }
    }
    const user = sessionStorage.getItem("user")
    sessionStorage.clear();
    sessionStorage.setItem("cart", JSON.stringify(cart))
    sessionStorage.setItem("user", user)
    window.location.href = "ShoppingBag.html"
}

const placeOrder = async () => {
    if (sessionStorage.getItem("user") == null) {
        window.location.href = "home.html"
    }
    const userJson = sessionStorage.getItem("user")
    const user = JSON.parse(userJson)

    const orderItemsArr = [];
    const cartJson = sessionStorage.getItem("cart")
    const cart = JSON.parse(cartJson)
    for (let i = 0; i < cart.length; i++) {
        if (orderItemsArr.find(p => p.ProductId == products[i].productId)) {
            const q = orderItemsArr.find(p => p.ProductId == products[i].productId);
            q.Quantity++;
        }
        else {
            let orderItem = {
                ProductId: products[i].productId,
                Quantity: 1
            }
            orderItemsArr.push(orderItem);
        }
    }

    const order = {
        OrderSum: totalAmount,
        OrderDate: new Date(),
        UserId: user.userId,
        OrderItems: orderItemsArr
    }

    try {
        const res = await fetch(`api/Order`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(order)
        })
        if (!res.ok)
            alert("Sorry, your order isn't created, Try again")
        else {
            const res2 = await res.json()
            alert(`user ${order.UserId} added order successfully, in all for payment is ${res2.orderSum}`)
            //alert(`סך הכל לתשלום ${res2.totalAmount}`)
            window.location.href = "order.html"
        }
    }
    catch (e) {
        alert(e);
    }
}
