import { useState } from "react";
import { useNavigate } from "react-router-dom";

export default function Form() {
  const navigate = useNavigate();
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  //check for errors
  const [submitted, setSubmitted] = useState(false);
  const [error, setError] = useState(false);
  const [existsError, setExistsError] = useState(false);

  //handle name change
  const handleName = (e) => {
    setName(e.target.value);
    setSubmitted(false);
  };

  //handle email change
  const handleEmail = (e) => {
    setEmail(e.target.value);
    setSubmitted(false);
  }

  //handle password
  const handlePassword = (e) => {
    setPassword(e.target.value);
    setSubmitted(false);
  };

  const setCartId = (cartId) => {
    if (cartId !== 0) {
      sessionStorage.setItem('cartId', cartId.toString());
    }
  };

    const register = (userId) => {
      if (userId !== 0) {
        sessionStorage.setItem('userId', userId.toString());
        fetch(`http://localhost:44478/api/cart/${userId}`, {
          method: "GET"
        })
          .then(response => response.json())
          .then(result => setCartId(result))
          .catch(error => console.log("Error: ", error));
        setSubmitted(true);
        setError(false);
        setExistsError(false);
        navigate('/products');
       } else {
         setExistsError(true);
       }
    };


  //handle form submission
  const handleSubmit = (e) => {
    e.preventDefault();
    if (name === "" || email === "" || password === "") {
      setError(true);
    } else {

        const userInfo = {
            Name: name,
            Email: email,
            Password: password,
        };
      fetch(`http://localhost:44478/api/user`, {
          method: "POST",
          headers: {
              'Accept': 'application/json',
              'Content-Type':'application/json'
          },
          body: JSON.stringify(userInfo),
      })
          .then(response => response.json())
          .then(result => register(result))
          .catch(error => console.log("Error: ", error));
    }
  };

  //show success message
  const successMessage = () => {
    return (
      <div
        className="success"
        style={{
          display: submitted ? "" : "none",
        }}
      >
        <h1> User {name} successfully registered!</h1>
      </div>
    );
  };

  //show empty field error message
  const errorMessage = () => {
    return (
      <div
        className="error"
        style={{
          display: error ? "" : "none",
        }}
      >
        <h1>Please enter all the fields</h1>
      </div>
    );
  };

  //show user already exists error message
  const existsErrorMessage = () => {
    return (
      <div
        className="existsError"
        style={{
          display: existsError ? "" : "none",
        }}
      >
        <h1>User already exists</h1>
      </div>
    );
  };

  return (
    <div className="Register">
      <header className="Login-Register-header">Register</header>
      {/* Calling to methods */}
      <div className="messages">
        {errorMessage()}
        {existsErrorMessage()}
        {successMessage()}
      </div>
      <form onSubmit={handleSubmit}>
        {/* Labels and inputs for form date */}
        <label className="input-label">Username</label>
        <br />
        <input
          onChange={handleName}
          className="text-box"
          value={name}
          type="text"
          required
        />
        <br />
        <label className="input-label">Email</label>
        <br />
        <input
          onChange={handleEmail}
          className="text-box"
          value={email}
          type="email"
          required
        />
        <br />
        <label className="label">Password</label>
        <br />
        <input
          onChange={handlePassword}
          className="text-box"
          value={password}
          type="password"
          required
        />
        <br />
        <input className="button" type="submit" value="Register">
        </input>
        or
        <button onClick={() => navigate('/ ')} className="button" type="button">
          Go Back
        </button>
      </form>
    </div>
  );
}