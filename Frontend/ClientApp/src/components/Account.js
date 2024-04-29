import "../styles.css";
import React, { Component } from "react";
import AccountForm from "./AccountForm";

export class Account extends Component {
  static displayName = Account.name;

  render() {
    return (
      <div className="Container">
        <img
          src="https://i.imgur.com/1dK701w.png"
          alt="logo"
          className="logo"
          draggable="false"
        />
        <AccountForm />
      </div>
    );
  }
}
