import "../styles.css";
import React, { Component } from 'react';
import { NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';

export class Login extends Component {
  static displayName = Login.name;

  render() {
    return (
      <div className="Container">
        <img
          src="https://en.expensereduction.com/wp-content/uploads/2018/02/logo-placeholder-300x68.png"
          alt="logo"
          className="logo"
        />
        <div className="Login">
          <form>
            <label for="username">Username:</label>
            <br />
            <input
              id="username"
              name="username"
              type="text"
              className="text-box"
              required
            ></input>
            <br />
            <label for="password">Password:</label>
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
              value="Login"
              className="login-button"
            ></input>
            <br />
            or
            <br />
            <NavLink tag={Link} to="/register" className="register-button">
              Register
            </NavLink>
          </form>
        </div>
      </div>
    );
  }
}
