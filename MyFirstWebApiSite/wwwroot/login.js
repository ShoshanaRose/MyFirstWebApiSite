const newU = () => {
    const registerUser = document.getElementById("register")
    registerUser.style.visibility = "initial"
}

const viewUpdate = () => {
    const view = document.getElementById("update");
    view.style.visibility = "initial";
}

const viewProduct = () => {
    window.location.href = "Products.html"
}

const login = async () => {
    const userDTO = {
        Email: document.getElementById("usernameLogin").value,
        Password: document.getElementById("passwordLogin").value
    }
    try {
        const res = await fetch(`api/User/login`, {
            method: 'POST',
            headers: { "Content-Type": 'application/json' },
            body: JSON.stringify(userDTO)
        });
        if (res.status == 204)
            alert("שם או סיסמא אינם תקינים")
        else if (res.status == 400)
            alert("error in connect to db")
        else {
            const res2 = await res.json();
            sessionStorage.setItem("user", JSON.stringify(res2))
            alert(`welcome ${res2.firstName.trim()} ${res2.lastName.trim()}!!!`)
            window.location.href = "UserDetails.html"
        }
    }
    catch (er) {
        alert(er);
    }
}

const register = async () => {
    const user = {
        UserName: document.getElementById("usernameRegister").value,
        Password: document.getElementById("passwordRegister").value,
        Firstname: document.getElementById("firstname").value,
        Lastname: document.getElementById("lastname").value
    }
    const check = await checkStrong()
    if (check == 0) {
        return alert("להמשך הרישום יש להכניס סיסמא חזקה")
    }
    try {
        const newuserFetch = await fetch(`api/User`, {
            method: 'POST',
            headers: { "Content-Type": 'application/json' },
            body: JSON.stringify(user)
        });
        if (!newuserFetch.ok)
            return alert("משהו השתבש, נסה שנית")
        else {
            const newUser = await newuserFetch.json();
            return alert(`נרשם בהצלחה ${newUser.Firstname.trim()}`)
        }
    }
    catch (e) {
        console.log(e)
    }
}

const checkStrong = async () => {
    let pass = document.getElementById("passwordRegister").value;
    const progress = document.getElementById("progress");
    try {
        const res = await fetch('api/User/checkPassword', {
            method: 'POST',
            headers: { "Content-Type": 'application/json' },
            body: JSON.stringify(pass)
        })
        if (res.status == 204) {
            alert("אירעה שגיאה, נסה שנית");
            return 0;
        }
        if (res.status == 400) {
            alert("נסה סיסמא אחרת");
            return 0;
        }

        const score = await res.json()
        progress.value = score;
        console.log(score)
        if (score < 2) {
            //document.getElementById("password2").innerHTML =""
            alert(`הסיסמה קלה מדי, אנא הכנס סיסמא אחרת `)
            return 0;
        }
        else {
            alert("הסיסמא שלך חזקה!!! אפשר להמשיך")
            return 2;
        }
    }
    catch (e) {
        alert(e)
    }
}

const update = async () => {
    const user = {
        UserId: 0,
        Email: document.getElementById("usernameUpdate").value,
        Password: document.getElementById("passwordUpdate").value,
        Firstname: document.getElementById("firstnameUpdate").value,
        Lastname: document.getElementById("lastnameUpdate").value
    }
    const checkPass = await checkStrong()
    if (checkPass < 2) {
        return alert("Please enter strong password!");
    }

    try {
        const userJson = sessionStorage.getItem("user")
        user.UserId = JSON.parse(userJson).userId;
        console.log(user.UserId)
        const res = await fetch(`api/User/${user.UserId}`, {
            method: 'PUT',
            Headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(user)
        })
        console.log(res)
        if (res.status == 400)
            alert("משהו השתבש, נסה שנית")
        else {

            sessionStorage.setItem("user", JSON.stringify(user))
            let userString = sessionStorage.getItem("user")
            let cu = JSON.parse(userString)

            alert(`user ${cu.userName} was updated`)

            alert(" הפרטים עודכנו בהצלחה")
            window.location.href = './home.html';
        }
    }

    //const checkIfStrong = await checkStrongPassword()

    //if (!checkIfStrong) {
    //    return alert("Please enter strong password!");
    //}

    //try {
    //    const userJson = sessionStorage.getItem("user")
    //    console.log(userJson);
    //    const id = JSON.parse(userJson).userId
    //    user.UserId = id;
    //    const res = await fetch(`api/User/${id}`,
    //        {
    //            method: 'PUT',
    //            headers: { 'Content-Type': `application/json` },
    //            body: JSON.stringify(user)
    //        })
    //    if (!res.ok)
    //        alert("error updated to the server,please try again!")
    //    else {

    //        alert(`user ${id} updated succfully`)
    //    }

    //}
    catch (e) {
        alert("catch");
        console.log(e)
    }
}
