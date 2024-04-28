import "../styles.css";
import React, { Component } from "react";
import CheckoutForm from "./CheckoutForm";

export class Checkout extends Component {
  static displayName = Checkout.name;

  render() {
    return (
      <div className="Container">
        <img
          src="https://i.imgur.com/1dK701w.png"
          alt="logo"
          className="logo"
          draggable="false"
        />
        <CheckoutForm />
      </div>
    );
  }
}
