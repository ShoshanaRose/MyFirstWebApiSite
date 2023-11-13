var product = [];
var category = [];

const getProduct = async () => {    
    try {
        const res = await fetch(`api/Product`)
        if (res.status == 400)
            return alert("error in connecrion DB");
        if (res.status == 204)
            return alert("no product");
        
        product = await res.json(); 
        return product;
    }
    catch (er) {
        alert(er);
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

const ShowProduct = async () => {
    const product = await getProduct()
    console.log(product)    
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
    console.log(category)
    for (let i = 0; i < category.length; i++) {
        const tmp = document.querySelector("#temp-category");
        const clone = tmp.content.cloneNode(true);
        clone.querySelector("label").innerText = category[i].categoryName;
        document.getElementById("categoryList").appendChild(clone);
    }
}

ShowProduct();
ShowCategory();

const filterProducts = () => {
    const maxPrice = document.getElementById("maxPrice").value;
    const minPrice = document.getElementById("minPrice").value;
    //const nameFilter = document.getElementById("nameFilter").value;

    //if (nameFilter =="floatRight")
}