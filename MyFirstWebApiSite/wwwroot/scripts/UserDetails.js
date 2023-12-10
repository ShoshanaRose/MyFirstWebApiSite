
const viewUpdate = () => {
    const view = document.getElementById("update");
    view.style.visibility = "initial";
}

const viewProduct = () => {
    window.location.href = "Products.html"
}

const checkStrong = async () => {
    const pass = document.getElementById("passwordUpdate").value
    const progress = document.getElementById("progress")
    try {
        const res = await fetch('api/User/checkPassword', {
            method: 'POST',
            headers: { "Content-Type": 'application/json' },
            body: JSON.stringify(pass)
        })
        if (res.status == 204) {
            alert("����� �����, ��� ����");
            return 0;
        }
        if (res.status == 400) {
            alert("��� ����� ����");
            return 0;
        }

        const score = await res.json()
        progress.value = score;
        console.log(score)
        if (score < 2) {
            alert(`������ ��� ���, ��� ���� ����� ���� `)
            return 0;
        }
        else {
            alert("������ ��� ����!!! ���� ������")
            return 3;
        }
    }
    catch (e) {
        console.log(e)
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
        user.UserId = JSON.parse(userJson).userId
        const res = await fetch(`api/User/${user.UserId}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(user)
        })
        console.log(res)
        if (res.status == 400)
            alert("���� �����, ��� ����")
        else {
            sessionStorage.setItem("user", JSON.stringify(user))
            let userString = sessionStorage.getItem("user")
            let cu = JSON.parse(userString)

            alert(`user ${cu.userName} was updated`)
            alert(" ������ ������ ������")
            window.location.href = './home.html';
        }
    }
    catch (e) {
        console.log(e)
    }
}