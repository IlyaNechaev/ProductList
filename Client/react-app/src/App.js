import logo from "./logo.svg";
import "./App.css";
import { useState } from "react";

function App() {
  const [name, setName] = useState("");
  const [lastName, setLastName] = useState("");
  const [login, setLogin] = useState("");
  const [password, setPassword] = useState("");

  async function getUsers(e) {
    let response = await fetch("http://kali/api/users", {
      method: "GET",
      headers: {
        "Content-Type": "application/json; charset=utf-8",
      },
    });

    let users = await response.json();

    console.log("Пользователи:\n");
    console.log(users);
  }

  async function addUser(e) {
    let response = await fetch("http://kali/api/user/add", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
          firstName: name,
          lastName: lastName,
          login: login,
          password: password
      })
    });

    let users = await response.json();
    console.log(users);
  }

  return (
    <div className="main">
      <h2>Добавить нового пользователя</h2>
      <div className="form">
        <input
          type="text"
          placeholder="Имя"
          onChange={(e) => {
            setName(e.target.value);
          }}
        />
        <input
          type="text"
          placeholder="Фамилия"
          onChange={(e) => {
            setLastName(e.target.value);
          }}
        />
        <input
          type="text"
          placeholder="Логин"
          onChange={(e) => {
            setLogin(e.target.value);
          }}
        />
        <input
          type="password"
          placeholder="Пароль"
          onChange={(e) => {
            setPassword(e.target.value);
          }}
        />
        <input type="button" value="Добавить" onClick={addUser} />
        <input type="button" value="Пользователи" onClick={getUsers} />
      </div>
    </div>
  );
}

export default App;
