async function editUser(id, nameOne, nameTwo, nickname, hash, order) {

    let response = await fetch("https://localhost:7112/api/users", {
      method: "PUT",
      headers: {
        "Content-Type": "application/json; charset=utf-8"
      },
      body: JSON.stringify({
        objectID: id,
        firstName: nameOne,
        lastName: nameTwo,
        login: nickname,
        passwordHash: hash,
        orders: order
      })
    });

    let user = await response.json();
    console.log(user);
  }
