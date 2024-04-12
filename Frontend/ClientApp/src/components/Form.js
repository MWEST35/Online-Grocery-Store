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

  //handle form submission
  const handleSubmit = (e) => {
    e.preventDefault();
    if (name === "" || email === "" || password === "") {
      setError(true);
    } else {
      setSubmitted(true);
      setError(false);
      navigate('/products')
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

  return (
    <div className="Register">
      <header className="Login-Register-header">Register</header>
      {/* Calling to methods */}
      <div className="messages">
        {errorMessage()}
        {successMessage()}
      </div>
      <form>
        {/* Labels and inputs for form date */}
        <label className="input-label">Name</label>
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
        <input onClick={handleSubmit} className="button" type="submit" value="Register">
        </input>
        or
        <button onClick={() => navigate('/ ')} className="button" type="button">
          Go Back
        </button>
      </form>
    </div>
  );
}