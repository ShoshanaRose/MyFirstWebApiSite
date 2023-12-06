let cart = [];

const getProduct = async (name, minPrice, maxPrice, checkedCategory) => {     
    try {
        let url = `https://localhost:44392/api/Product`;
        if (name || minPrice || maxPrice || checkedCategory) url += `?`
        if (name) url += `&name=${name}`
        if (minPrice) url += `&minPrice=${minPrice}`
        if (maxPrice) url += `&maxPrice=${maxPrice}`
        if (checkedCategory) {
            for (let i = 0; i < checkedCategory.length; i++) {
                url += `&categoryIds=${checkedCategory[i]}`
            }               
        }
        const res = await fetch(url)
        if (res.status == 400)
            return alert("error in connection DB");
        if (res.status == 204)
            return alert("no product");       
        product = await res.json();
        return product;
    }
    catch (er) {
        console.log(er+"!!!!!!!!!");
    }
}

const getCategory = async () => {
    try {
        const res = await fetch(`api/Category`)
        if (res.status == 400)
            return alert("error in connecrion DB");
        if (res.status == 204)
            return alert("no category");

        category = await res.json();
        return category;
    }
    catch (er) {
        alert(er);
    }
}

const ShowProduct = async (name, minPrice, maxPrice, checkedCategory) => {
    const product = await getProduct(name, minPrice, maxPrice, checkedCategory)
    let cartSession = JSON.parse(sessionStorage.getItem("cart"));
    if (cartSession != null) {
        sessionStorage.setItem("cart", [])
        document.getElementById("ItemsCountText").innerHTML = cartSession.length;
        for (let c = 0; c < cartSession.length; c++) {
            cart.push(cartSession[c]);
        }
    }
    for (let i = 0; i < product.length; i++)
    {
        const tmp = document.querySelector("#temp-card");
        const clone = tmp.content.cloneNode(true);
        clone.querySelector("img").src = "/pictures/" + product[i].image;
        clone.querySelector("h1").innerText = product[i].productName;
        clone.querySelector("p.price").innerText = product[i].price;
        clone.querySelector("p.description").innerText = product[i].description;
        let btn = clone.querySelector("button");
        btn.addEventListener('click', () => { addToCart(product[i]) });
        document.getElementById("ProductList").appendChild(clone);
    }
}

const ShowCategory = async () => {
    const category = await getCategory()
    for (let i = 0; i < category.length; i++) {
        const tmp = document.querySelector("#temp-category");
        const clone = tmp.content.cloneNode(true);
        clone.querySelector("input").value = category[i].categoryName;
        clone.querySelector("input").id = category[i].categoryId;
        clone.querySelector(".OptionName").innerText = category[i].categoryName
        clone.querySelector("label").for = category[i].categoryName;
        document.getElementById("categoryList").appendChild(clone);
    }
}

ShowProduct();
ShowCategory();

const filterProducts = async () => {  
    let minPrice = document.getElementById("minPrice").value
    let maxPrice = document.getElementById("maxPrice").value
    let name = document.getElementById("nameSearch").value
    let category = document.querySelectorAll(".opt");
    const checkedCategory = [];
    for (let i = 0; i < category.length; i++) {
        if (category[i].checked)
            checkedCategory.push(category[i].id)
    }
    document.getElementById("ProductList").replaceChildren([])
    await ShowProduct(name, minPrice, maxPrice, checkedCategory)  
}

const addToCart = (product) => {
    cart.push(product)
    document.getElementById("ItemsCountText").innerHTML++;
    sessionStorage.setItem(`cart`, JSON.stringify(cart));
}