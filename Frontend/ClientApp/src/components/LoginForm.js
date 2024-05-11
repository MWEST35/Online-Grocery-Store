import { useState } from "react";
import { useNavigate } from "react-router-dom";

export default function LoginForm() {
  const navigate = useNavigate();
  const [username_email, setUsername_email] = useState("");
  const [password, setPassword] = useState("");

  const handleUsername_email = (e) => {
    setUsername_email(e.target.value);
  };

  const handlePassword = (e) => {
    setPassword(e.target.value);
  };

  const setCartId = (cartId) => {
    if (cartId !== 0) {
      sessionStorage.setItem('cartId', cartId.toString());
    }
  };

  const login = (userId) => {
    if (userId !== 0) {
      sessionStorage.setItem('userId', userId.toString());
      fetch(`http://localhost:44478/api/cart/${userId}`, {
        method: "GET"
      })
        .then(response => response.json())
        .then(result => setCartId(result))
        .catch(error => console.log("Error: ", error));
      navigate('/products');
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    fetch(`http://localhost:44478/api/user/${username_email}/${password}`, {
      method: "GET"
    })
      .then(response => response.json())
      .then(result => login(result))
      .catch(error => console.log("Error: ", error));
  };


  

  return (
    <div className="Login">
      <header className="Login-Register-header">Log In</header>
      <form onSubmit={handleSubmit}>
        <label for="username-email" className="input-label">Username or Email</label>
        <br />
        <input
          id="username-email"
          name="username-email"
          type="text"
          className="text-box"
          value={username_email}
          onChange={handleUsername_email}
          required
        ></input>
        <br />
        <label for="password" className="input-label">Password</label>
        <br />
        <input
          id="password"
          name="password"
          type="password"
          className="text-box"
          value={password}
          onChange={handlePassword}
          required
        ></input>
        <br />
        <input
          type="submit"
          value="Log In"
          className="button"
        ></input>
        or
        <button onClick={() => navigate('/register')} className="button">
          Register
        </button>
      </form>
    </div>
  );
}