const newU = () => {
    const registeru = document.getElementById("register")
    registeru.style.visibility = "initial"
}

const viewUpdate = () => {
    const view = document.getElementById("update");
    view.style.visibility = "initial";
}

const viewProduct = () => {
    window.location.href = "Products.html"
}

const login = async () => {
    try {
        const UserName = document.getElementById("username").value
        const pass = document.getElementById("password").value
        Password = parseInt(pass)
        console.log(Password)
        const res = await fetch(`api/User?UserName=${UserName}&Password=${Password}`)
        if (res.status==204) 
            window.alert("שם או סיסמא אינם תקינים")
        else if (res.status == 400) 
            alert("error in connect to db")
        else {
            const res2 = await res.json();
            sessionStorage.setItem("user", JSON.stringify(res2))
            alert("welcome!!!")
            window.location.href = "UserDetails.html"
        }
    }
    catch (er) {
        alert(er);
    }
}

const register = async () => {
    const user = {
        UserName: document.getElementById("username2").value,
        Password: document.getElementById("password2").value,
        Firstname: document.getElementById("firstname").value,
        Lastname: document.getElementById("lastname").value
    }
    const check = await checkStrong()
    console.log(check)
    if (check<=1) {
        return alert("להמשך הרישום יש להכניס סיסמא חזקה")
    }
    try {
        const newuser = await fetch('api/User', {
            method: 'POST',
            headers: { "Content-Type": 'application/json'},
            body: JSON.stringify(user)
        });
        if (!newuser.ok)
            alert("משהו השתבש, נסה שנית")
        else {
            const res2 = await newuser.json();
            alert(`נרשם בהצלחה ${res2.userName}`)
        }
    }
    catch (e) {
        console.log(e)
        //alert("?????????????");  
    }
}

const checkStrong = async () => {
    const pass = document.getElementById("password2").value;
    const progress = document.getElementById("progress");
    //const valuePass = document.getElementById("value");
    try {
        const res = await fetch('api/User/checkPassword', {
            method: 'POST',
            headers: { "Content-Type": 'application/json' },
            body: JSON.stringify(pass)
        })
        if (res.status==204) {
            alert("אירעה שגיאה, נסה שנית");
            return 0;
        }
                  
        const score = await res.json()
        progress.value = score;
        //valuePass.value = score;
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
    catch(e) {
        alert(e)
    }
}

const update = async () => {
    const user = {
        UserId: 0, 
        Email: document.getElementById("username3").value,
        Password: document.getElementById("password3").value,
        Firstname: document.getElementById("firstname3").value,
        Lastname: document.getElementById("lastname3").value
    }
    //checkStrong();
    try {
        const userJson = sessionStorage.getItem("user")
        user.UserId = JSON.parse(userJson).userId;
        console.log(user.UserId)
        /*const id = JSON.parse(userJson).UserId;*/
        const res = await fetch(`api/User/${user.UserId}`, {
            method: 'PUT',
            Headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(user)
        })
        console.log(res)
        if (res.status==400)
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

    //const user = {
    //    UserId: 0,
    //    Email: document.getElementById("userNameRegister").value,
    //    Password: document.getElementById("passwordRegister").value,
    //    FirstName: document.getElementById("FirstName").value,
    //    LastName: document.getElementById("LastName").value
    //}

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
