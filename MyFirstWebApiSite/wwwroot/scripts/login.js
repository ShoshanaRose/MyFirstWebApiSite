const newU = () => {
    const registerUser = document.getElementById("register")
    registerUser.style.visibility = "initial"
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

    let fName = document.getElementById("firstname").value
    if (fName.length > 15) {
        alert("First Name is too long");
    } 

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
            headers: { 'Content-Type': 'application/json' },
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
    const pass = document.getElementById("passwordRegister").value
    const progress = document.getElementById("progress")
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
