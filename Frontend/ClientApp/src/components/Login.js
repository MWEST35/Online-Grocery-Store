import "../styles.css";
import React, { Component } from 'react';
import LoginForm from "./LoginForm";

export class Login extends Component {
  static displayName = Login.name;

    render() {
    return (
      <div className="Container">
            <img
          src="grocery-logo.png"
          alt="logo"
          className="logo"
          draggable="false"
        />
        <LoginForm />
      </div>
    );
  }
}
