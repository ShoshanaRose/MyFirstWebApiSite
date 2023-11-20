var products = [];

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
        console.log(url)
        const res = await fetch(url)
        if (res.status == 400)
            return alert("error in connecrion DB");
        if (res.status == 204)
            return alert("no product");
        
        product = await res.json();
        //console.log(product)
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
    for (let i = 0; i < product.length; i++)
    {
        const tmp = document.querySelector("#temp-card");
        const clone = tmp.content.cloneNode(true);
        clone.querySelector("img").src = "/pictures/" + product[i].image;
        clone.querySelector("h1").innerText = product[i].productName;
        clone.querySelector("p.price").innerText = product[i].price;
        clone.querySelector("p.description").innerText = product[i].description;
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

    /*
    let tmp = document.getElementById("temp-category");
    */
}

ShowProduct();
ShowCategory();

const filterProducts = async () => {   
    let minPrice = document.getElementById("minPrice").value
    let maxPrice = document.getElementById("maxPrice").value
    let name = document.getElementById("nameSearch").value
    let category = document.querySelector(".opt");
    console.log(category)
    const checkedCategory = [];
    for (let i = 0; i < category.length; i++) {
        console.log(category[i], "!!!!!!!!!!!!!!!!")
        if (category[i].checked)
            checkedCategory.push(category[i])
    }
    document.getElementById("ProductList").replaceChildren([])
    products = await ShowProduct(name, minPrice, maxPrice, checkedCategory)  
}


const addToCart = async (product) => { 
    const res = await fetch(`api/Order}`, {
        method: 'POST',
        Headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(product)
    })
    const res2 = res.json();
}
