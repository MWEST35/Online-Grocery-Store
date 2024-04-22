import "../styles.css";
import { useState } from "react";

export default function AccountForm() {
  const [editAccount, setEditAccount] = useState({
    username: false,
    email: false,
    password: false,
  });
  const [username, setUsername] = useState("Username");
  const [email, setEmail] = useState("Email@email");
  const [password, setPassword] = useState("password");
  const [accountChanged, setAccountChanged] = useState(false);

  const [editPersonal, setEditPersonal] = useState({
    name: false,
    phone: false,
    card: false,
    shipping: false,
  });
  const [name, setName] = useState("First Middle Last");
  const [phone, setPhone] = useState("134-314-4324");
  const [card, setCard] = useState({
    name: "Cardholder Name",
    num: "1223 123123 12321",
    date: "12/12",
    cvv: "100",
  });
  const [shipping, setShipping] = useState({
    address: "1021 N 16th Street",
    state: "Nebraska",
    city: "Lincoln",
    zip: 68151,
  });
  const [personalChanged, setPersonalChanged] = useState(false);

  const handleUsername = (e) => {
    setUsername(e.target.value);
  };

  const handleEmail = (e) => {
    setEmail(e.target.value);
  };

  const handlePassword = (e) => {
    setPassword(e.target.value);
  };

  const changeEditAccount = (e) => {
    if (!accountChanged) {
      changeAccountChanged();
    }
    switch (e) {
      case "username":
        setEditAccount({ username: true });
        break;
      case "email":
        setEditAccount({ email: true });
        break;
      case "password":
        setEditAccount({ password: true });
        break;
      default:
        break;
    }
  };

  const handleSubmitAccount = (e) => {
    e.preventDefault();
    setAccountChanged();
    setEditAccount({
      username: false,
      email: false,
      password: false,
    });
  };

  const changeAccountChanged = () => {
    setAccountChanged(!accountChanged);
  };

  const changePersonalChanged = () => {
    setPersonalChanged(!personalChanged);
  };
  const changeEditPersonal = (e) => {
    if (!personalChanged) {
      changePersonalChanged();
    }
    switch (e) {
      case "name":
        setEditPersonal({ name: true });
        break;
      case "phone":
        setEditPersonal({ phone: true });
        break;
      case "card":
        setEditPersonal({ card: true });
        break;
      case "shipping":
        setEditPersonal({ shipping: true });
        break;
      default:
        break;
    }
  };

  const handleName = (e) => {
    setName(e.target.value);
  };

  const handlePhone = (e) => {
    setPhone(e.target.value);
  };

  const handleCardName = (e) => {
    setCard({
      name: e.target.value,
      num: card.num,
      cvv: card.cvv,
      date: card.date,
    });
  };

  const handleCardNum = (e) => {
    setCard({
      name: card.name,
      num: e.target.value,
      cvv: card.cvv,
      date: card.date,
    });
  };

  const handleCardCvv = (e) => {
    setCard({
      name: card.name,
      num: card.num,
      cvv: e.target.value,
      date: card.date,
    });
  };

  const handleCardDate = (e) => {
    setCard({
      name: card.name,
      num: card.num,
      cvv: card.cvv,
      date: e.target.value,
    });
  };

  const handleShippingAddress = (e) => {
    setShipping({
      address: e.target.value,
      state: shipping.state,
      city: shipping.city,
      zip: shipping.zip,
    });
  };

  const handleShippingState = (e) => {
    setShipping({
      address: shipping.address,
      state: e.target.value,
      city: shipping.city,
      zip: shipping.zip,
    });
  };

  const handleShippingCity = (e) => {
    setShipping({
      address: shipping.address,
      state: shipping.state,
      city: e.target.value,
      zip: shipping.zip,
    });
  };

  const handleShippingZip = (e) => {
    setShipping({
      address: shipping.address,
      state: shipping.state,
      city: shipping.city,
      zip: e.target.value,
    });
  };

  const handleSubmitPersonal = (e) => {
    e.preventDefault();
    changePersonalChanged();
    setEditPersonal({
      name: false,
      phone: false,
      card: false,
      shipping: false
    });
  };

  return (
    <div className="Account">
      <div className="Account-Info">
        <header className="Login-Register-header">Account Info</header>
        <form onSubmit={handleSubmitAccount}>
          <div style={{ display: editAccount.username ? "" : "none" }}>
            <label for="username">Username: </label>
            <input
              className="text-box-info"
              id="username"
              name="username"
              type="text"
              value={username}
              onChange={handleUsername}
              required
            />
          </div>
          <div style={{ display: !editAccount.username ? "" : "none" }}>
            Username: {username}{" "}
            <img
              src="https://cdn5.vectorstock.com/i/1000x1000/95/69/edit-icon-pencil-sign-up-vector-30669569.jpg"
              alt="edit button"
              width="15px"
              onClick={() => changeEditAccount("username")}
            />
          </div>
          <div style={{ display: editAccount.email ? "" : "none" }}>
            <label for="email">Email: </label>
            <input
              className="text-box-info"
              id="Email"
              name="Email"
              type="email"
              value={email}
              onChange={handleEmail}
              required
            ></input>
          </div>
          <div style={{ display: !editAccount.email ? "" : "none" }}>
            Email: {email}{" "}
            <img
              src="https://cdn5.vectorstock.com/i/1000x1000/95/69/edit-icon-pencil-sign-up-vector-30669569.jpg"
              alt="edit button"
              width="15px"
              onClick={() => changeEditAccount("email")}
            />
          </div>
          <div style={{ display: editAccount.password ? "" : "none" }}>
            <label for="password">Password: </label>
            <input
              className="text-box-info"
              id="password"
              name="password"
              type="text"
              value={password}
              onChange={handlePassword}
              required
            ></input>
          </div>
          <div style={{ display: !editAccount.password ? "" : "none" }}>
            Password: {password}{" "}
            <img
              src="https://cdn5.vectorstock.com/i/1000x1000/95/69/edit-icon-pencil-sign-up-vector-30669569.jpg"
              alt="edit button"
              width="15px"
              onClick={() => changeEditAccount("password")}
            />
          </div>
          <input
            type="submit"
            value="Save Changes"
            style={{ display: accountChanged ? "" : "none" }}
          />
        </form>
      </div>
      <div className="Personal-Info">
        <header className="Login-Register-header">Personal Info</header>
        <form onSubmit={handleSubmitPersonal}>
          <div style={{ display: editPersonal.name ? "" : "none" }}>
            <label for="name">Name: </label>
            <input
              className="text-box-info"
              id="name"
              name="name"
              type="text"
              value={name}
              onChange={handleName}
              required
            />
          </div>
          <div style={{ display: !editPersonal.name ? "" : "none" }}>
            Name: {name}{" "}
            <img
              src="https://cdn5.vectorstock.com/i/1000x1000/95/69/edit-icon-pencil-sign-up-vector-30669569.jpg"
              alt="edit button"
              width="15px"
              onClick={() => changeEditPersonal("name")}
            />
          </div>
          <div style={{ display: editPersonal.phone ? "" : "none" }}>
            <label for="phone-number">Phone Number: </label>
            <input
              className="text-box-info"
              id="phone-number"
              name="phone-number"
              type="phone"
              value={phone}
              onChange={handlePhone}
              required
            ></input>
          </div>
          <div style={{ display: !editPersonal.phone ? "" : "none" }}>
            Phone Number: {phone}{" "}
            <img
              src="https://cdn5.vectorstock.com/i/1000x1000/95/69/edit-icon-pencil-sign-up-vector-30669569.jpg"
              alt="edit button"
              width="15px"
              onClick={() => changeEditPersonal("phone")}
            />
          </div>
          Card Info:{" "}
          <img
            src="https://cdn5.vectorstock.com/i/1000x1000/95/69/edit-icon-pencil-sign-up-vector-30669569.jpg"
            alt="edit button"
            width="15px"
            onClick={() => changeEditPersonal("card")}
            style={{ display: !editPersonal.card ? "" : "none" }}
          />
          <br />
          <ul style={{ display: editPersonal.card ? "" : "none" }}>
            <label for="card-name">Cardholder Name: </label>
            <input
              className="text-box-info"
              id="card-name"
              name="card-name"
              type="text"
              value={card.name}
              onChange={handleCardName}
              required
            ></input>
            <label for="card-num">Number: </label>
            <input
              className="text-box-info"
              id="card-num"
              name="card-num"
              type="text"
              value={card.num}
              onChange={handleCardNum}
              required
            ></input>
            <label for="card-cvv">cvv: </label>
            <input
              className="text-box-info"
              id="card-cvv"
              name="card-cvv"
              type="text"
              value={card.cvv}
              onChange={handleCardCvv}
              required
            ></input>
            <label for="card-date">Exp. Date: </label>
            <input
              className="text-box-info"
              id="card-date"
              name="card-date"
              type="text"
              value={card.date}
              onChange={handleCardDate}
              required
            ></input>
          </ul>
          <ul style={{ display: !editPersonal.card ? "" : "none" }}>
            Name: {card.name} <br />
            Number: {card.num} <br />
            CVV: {card.cvv} <br />
            Exp. Date: {card.date}
          </ul>
          Shipping Info:{" "}
          <img
            src="https://cdn5.vectorstock.com/i/1000x1000/95/69/edit-icon-pencil-sign-up-vector-30669569.jpg"
            alt="edit button"
            width="15px"
            onClick={() => changeEditPersonal("shipping")}
            style={{ display: !editPersonal.shipping ? "" : "none" }}
          />
          <br />
          <ul style={{ display: editPersonal.shipping ? "" : "none" }}>
            <label for="address">Address: </label>
            <input
              className="text-box-info"
              id="address"
              name="address"
              type="text"
              value={shipping.address}
              onChange={handleShippingAddress}
              required
            ></input>
            <label for="state">State: </label>
            <input
              className="text-box-info"
              id="state"
              name="state"
              type="text"
              value={shipping.state}
              onChange={handleShippingState}
              required
            ></input>
            <label for="city">City: </label>
            <input
              className="text-box-info"
              id="city"
              name="city"
              type="text"
              value={shipping.city}
              onChange={handleShippingCity}
              required
            ></input>
            <label for="zip">Zip Code: </label>
            <input
              className="text-box-info"
              id="zip"
              name="zip"
              type="zip"
              value={shipping.zip}
              onChange={handleShippingZip}
              required
            ></input>
          </ul>
          <ul style={{ display: !editPersonal.shipping ? "" : "none" }}>
            Address: {shipping.address} <br />
            State: {shipping.state} <br />
            City: {shipping.city} <br />
            ZIP: {shipping.zip}
          </ul>
          <input
            type="submit"
            value="Save Changes"
            style={{ display: personalChanged ? "" : "none" }}
          />
        </form>
      </div>
    </div>
  );
}
