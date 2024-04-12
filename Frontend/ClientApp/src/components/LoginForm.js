import { useNavigate } from "react-router-dom";

export default function LoginForm() {
  const navigate = useNavigate();

  return (
    <div className="Login">
      <header className="Login-Register-header">Log In</header>
      <form>
        <label for="username-email" className="input-label">Username or Email</label>
        <br />
        <input
          id="username-email"
          name="username-email"
          type="text"
          className="text-box"
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