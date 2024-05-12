import "../styles.css";
import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
export default function AccountForm() {
  const navigate = useNavigate();
  const [editAccount, setEditAccount] = useState({
    username: false,
    email: false,
    password: false,
  });
  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [accountChanged, setAccountChanged] = useState(false);

  const handleUsername = (e) => {
    setUsername(e.target.value);
  };

  const handleEmail = (e) => {
    setEmail(e.target.value);
  };

  const handlePassword = (e) => {
    setPassword(e.target.value);
  };

  const changeAccountChanged = () => {
    setAccountChanged(!accountChanged);
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
    fetch(`http://localhost:44478/api/user/${sessionStorage.getItem('userId')}/${username}/${email}/${password}`, {
      method: 'PUT',
    })
      .then(response => response.json())
      .then(result => console.log("result"))
      .catch(error => console.log("Error: ", error));
  };

  const [editPersonal, setEditPersonal] = useState({
    name: false,
    phone: false,
  });
  const [name, setName] = useState("");
  const [phone, setPhone] = useState("");
  const [personalChanged, setPersonalChanged] = useState(false);

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

  const handleSubmitPersonal = (e) => {
    e.preventDefault();
    changePersonalChanged();
    setEditPersonal({
      name: false,
      phone: false,
    });
    fetch(`http://localhost:44478/api/user/${sessionStorage.getItem('userId') }/${name}/${phone}`, {
      method: 'PUT',
    })
      .then(response => response.json())
      .then(result => console.log("result"))
      .catch(error => console.log("Error: ", error));
  };

  const [editCard, setEditCard] = useState({
    name: false,
    number: false,
    cvv: false,
    date: false,
  });
  const [card, setCard] = useState({
    name: "",
    num: "",
    date: "",
    cvv: "",
  });
  const [cardChanged, setCardChanged] = useState(false);

  const changeCardChanged = (e) => {
    setCardChanged(!cardChanged);
  };

  const changeEditCard = (e) => {
    if (!cardChanged) {
      changeCardChanged();
    }
    switch (e) {
      case "name":
        setEditCard({ name: true });
        break;
      case "num":
        setEditCard({ num: true });
        break;
      case "cvv":
        setEditCard({ cvv: true });
        break;
      case "date":
        setEditCard({ date: true });
        break;
      default:
        break;
    }
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

  const handleSubmitCard = (e) => {
    e.preventDefault();
    setCardChanged();
    setEditCard({
      name: false,
      num: false,
      cvv: false,
      date: false,
    });
    fetch(`http://localhost:44478/api/card/${sessionStorage.getItem('userId') }/${card.name}/${card.num}/${card.cvv}/${card.date}`, {
      method: 'PUT',
    })
      .then(response => response.json())
      .then(result => console.log("result"))
      .catch(error => console.log("Error: ", error));
  };

  const [editShipping, setEditShipping] = useState({
    address: false,
    state: false,
    city: false,
    zip: false,
  });
  const [shipping, setShipping] = useState({
    address: "",
    state: "",
    city: "",
    zip: 0,
  });
  const [shippingChanged, setShippingChanged] = useState(false);

  const changeShippingChanged = () => {
    setShippingChanged(!shippingChanged);
  };

  const changeEditShipping = (e) => {
    if (!shippingChanged) {
      changeShippingChanged();
    }
    switch (e) {
      case "address":
        setEditShipping({ address: true });
        break;
      case "state":
        setEditShipping({ state: true });
        break;
      case "city":
        setEditShipping({ city: true });
        break;
      case "zip":
        setEditShipping({ zip: true });
        break;
      default:
        break;
    }
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

  const handleSubmitShipping = (e) => {
    e.preventDefault();
    setShippingChanged();
    setEditShipping({
      address: false,
      state: false,
      city: false,
      zip: false,
    });
    fetch(`http://localhost:44478/api/shipping/${sessionStorage.getItem('userId') }/${shipping.address}/${shipping.state}/${shipping.city}/${shipping.zip}`, {
      method: 'PUT',
    })
      .then(response => response.json())
      .then(result => console.log("result"))
      .catch(error => console.log("Error: ", error));
  };

  const logOut = () => {
    sessionStorage.setItem('userId', 0);
    sessionStorage.setItem('cartId', 0);
    navigate("/");
  }

  const initAccountPersonal = (account_personal) => {
    setUsername(account_personal[0]);
    setEmail(account_personal[1]);
    setPassword(account_personal[2]);
    setName(account_personal[3]);
    setPhone(account_personal[4]);
  }

  const initShipping = (shipping) => {
    setShipping({ address: shipping[0], state: shipping[1], city: shipping[2], zip: shipping[3] });
  }

  const initCard = (card) => {
    setCard({ name: card[0], num: card[1], cvv: card[2], date: card[3] });
  }

  useEffect(() => {
    fetch(`http://localhost:44478/api/user/${sessionStorage.getItem('userId') }`, {
      method: 'GET',
    })
      .then(response => response.json())
      .then(result => initAccountPersonal(result))
      .catch(error => console.log("Error: ", error));
    fetch(`http://localhost:44478/api/shipping/${sessionStorage.getItem('userId') }`, {
      method: 'GET',
    })
      .then(response => response.json())
      .then(result => initShipping(result))
      .catch(error => console.log("Error: ", error));
    fetch(`http://localhost:44478/api/card/${sessionStorage.getItem('userId') }`, {
      method: 'GET',
    })
      .then(response => response.json())
      .then(result => initCard(result))
      .catch(error => console.log("Error: ", error));
  }, []);

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
            <img
              src="https://cdn5.vectorstock.com/i/1000x1000/95/69/edit-icon-pencil-sign-up-vector-30669569.jpg"
              alt="edit button"
              width="15px"
              onClick={() => changeEditAccount("username")}
            />{" "}
            Username: {username}
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
            <img
              src="https://cdn5.vectorstock.com/i/1000x1000/95/69/edit-icon-pencil-sign-up-vector-30669569.jpg"
              alt="edit button"
              width="15px"
              onClick={() => changeEditAccount("email")}
            />{" "}
            Email: {email}
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
            <img
              src="https://cdn5.vectorstock.com/i/1000x1000/95/69/edit-icon-pencil-sign-up-vector-30669569.jpg"
              alt="edit button"
              width="15px"
              onClick={() => changeEditAccount("password")}
            />{" "}
            Password: {password}
          </div>
          <input
            className="button-smaller"
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
            <img
              src="https://cdn5.vectorstock.com/i/1000x1000/95/69/edit-icon-pencil-sign-up-vector-30669569.jpg"
              alt="edit button"
              width="15px"
              onClick={() => changeEditPersonal("name")}
            />{" "}
            Name: {name}
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
              pattern="[0-9]{3}-[0-9]{3}-[0-9]{4}"
              placeholder="123-456-7890"
              required
            ></input>
          </div>
          <div style={{ display: !editPersonal.phone ? "" : "none" }}>
            <img
              src="https://cdn5.vectorstock.com/i/1000x1000/95/69/edit-icon-pencil-sign-up-vector-30669569.jpg"
              alt="edit button"
              width="15px"
              onClick={() => changeEditPersonal("phone")}
            />{" "}
            Phone Number: {phone}
          </div>
          <input
            className="button-smaller"
            type="submit"
            value="Save Changes"
            style={{ display: personalChanged ? "" : "none" }}
          />
        </form>
      </div>
      <div className="Shipping-Info">
        <header className="Login-Register-header">Shipping Info</header>
        <form onSubmit={handleSubmitShipping}>
          <div style={{ display: editShipping.address ? "" : "none" }}>
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
          </div>
          <div style={{ display: !editShipping.address ? "" : "none" }}>
            <img
              src="https://cdn5.vectorstock.com/i/1000x1000/95/69/edit-icon-pencil-sign-up-vector-30669569.jpg"
              alt="edit button"
              width="15px"
              onClick={() => changeEditShipping("address")}
            />{" "}
            Address: {shipping.address} <br />
          </div>
          <div style={{ display: editShipping.state ? "" : "none" }}>
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
          </div>
          <div style={{ display: !editShipping.state ? "" : "none" }}>
            <img
              src="https://cdn5.vectorstock.com/i/1000x1000/95/69/edit-icon-pencil-sign-up-vector-30669569.jpg"
              alt="edit button"
              width="15px"
              onClick={() => changeEditShipping("state")}
            />{" "}
            State: {shipping.state} <br />
          </div>
          <div style={{ display: editShipping.city ? "" : "none" }}>
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
          </div>
          <div style={{ display: !editShipping.city ? "" : "none" }}>
            <img
              src="https://cdn5.vectorstock.com/i/1000x1000/95/69/edit-icon-pencil-sign-up-vector-30669569.jpg"
              alt="edit button"
              width="15px"
              onClick={() => changeEditShipping("city")}
            />{" "}
            City: {shipping.city} <br />
          </div>
          <div style={{ display: editShipping.zip ? "" : "none" }}>
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
          </div>
          <div style={{ display: !editShipping.zip ? "" : "none" }}>
            <img
              src="https://cdn5.vectorstock.com/i/1000x1000/95/69/edit-icon-pencil-sign-up-vector-30669569.jpg"
              alt="edit button"
              width="15px"
              onClick={() => changeEditShipping("zip")}
            />{" "}
            ZIP: {shipping.zip}
          </div>
          <input
            className="button-smaller"
            type="submit"
            value="Save Changes"
            style={{ display: shippingChanged ? "" : "none" }}
          />
        </form>
      </div>
      <div className="Card-Info">
        <header className="Login-Register-header">Card Info</header>
        <form onSubmit={handleSubmitCard}>
          <div style={{ display: editCard.name ? "" : "none" }}>
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
          </div>
          <div style={{ display: !editCard.name ? "" : "none" }}>
            <img
              src="https://cdn5.vectorstock.com/i/1000x1000/95/69/edit-icon-pencil-sign-up-vector-30669569.jpg"
              alt="edit button"
              width="15px"
              onClick={() => changeEditCard("name")}
            />{" "}
            Name: {card.name} <br />
          </div>
          <div style={{ display: editCard.num ? "" : "none" }}>
            <label for="card-num">Number: </label>
            <input
              className="text-box-info"
              id="card-num"
              name="card-num"
              type="text"
              value={card.num}
              onChange={handleCardNum}
              pattern="[0-9]{14,16}"
              placeholder="01234567890123456"
              required
            ></input>
          </div>
          <div style={{ display: !editCard.num ? "" : "none" }}>
            <img
              src="https://cdn5.vectorstock.com/i/1000x1000/95/69/edit-icon-pencil-sign-up-vector-30669569.jpg"
              alt="edit button"
              width="15px"
              onClick={() => changeEditCard("num")}
            />{" "}
            Number: {card.num} <br />
          </div>
          <div style={{ display: editCard.cvv ? "" : "none" }}>
            <label for="card-cvv">CVV: </label>
            <input
              className="text-box-info"
              id="card-cvv"
              name="card-cvv"
              type="text"
              value={card.cvv}
              onChange={handleCardCvv}
              pattern="[0-9]{3,4}"
              placeholder="###"
              required
            ></input>
          </div>
          <div style={{ display: !editCard.cvv ? "" : "none" }}>
            <img
              src="https://cdn5.vectorstock.com/i/1000x1000/95/69/edit-icon-pencil-sign-up-vector-30669569.jpg"
              alt="edit button"
              width="15px"
              onClick={() => changeEditCard("cvv")}
            />{" "}
            CVV: {card.cvv} <br />
          </div>
          <div style={{ display: editCard.date ? "" : "none" }}>
            <label for="card-date">Exp. Date: </label>
            <input
              className="text-box-info"
              id="card-date"
              name="card-date"
              type="text"
              value={card.date}
              onChange={handleCardDate}
              pattern="[0-9]{2}/[0-9]{2}"
              placeholder="MM/YY"
              required
            ></input>
          </div>
          <div style={{ display: !editCard.date ? "" : "none" }}>
            <img
              src="https://cdn5.vectorstock.com/i/1000x1000/95/69/edit-icon-pencil-sign-up-vector-30669569.jpg"
              alt="edit button"
              width="15px"
              onClick={() => changeEditCard("date")}
            />{" "}
            Exp. Date: {card.date}
          </div>
          <input
            className="button-smaller"
            type="submit"
            value="Save Changes"
            style={{ display: cardChanged ? "" : "none" }}
          />
        </form>
      </div>
      <div className="Account-Buttons">
        <button onClick={logOut} className='button-smaller'>Log Out</button> or {' '}
        <button onClick={() => navigate('/products') } className='button-smaller'>Go To Products</button>
      </div>
      
    </div>
  );
}
