import "../styles.css";
import { useState, useEffect } from "react";
import { Link } from "react-router-dom";

export default function CheckoutForm() {
  const [editCard, setEditCard] = useState({
    name: false,
    number: false,
    cvv: false,
    date: false,
  });
  const [card, setCard] = useState({
    name: "Cardholder Name",
    num: "1223 123123 12321",
    date: "12/12",
    cvv: "100",
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
    address: "1021 N 16th Street",
    state: "Nebraska",
    city: "Lincoln",
    zip: 68151,
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

  const initShipping = (shipping) => {
    setShipping({ address: shipping[0], state: shipping[1], city: shipping[2], zip: shipping[3] });
  }

  const initCard = (card) => {
    setCard({ name: card[0], num: card[1], cvv: card[2], date: card[3] });
  }

  useEffect(() => {
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

  const [subtotal, setSubtotal] = useState("$21.50");
  const [tax, setTax] = useState("$1.50");
  const [total, setTotal] = useState("$23.50");

  const checkout = () => {
    fetch(`http://localhost:44478/api/cart/${sessionStorage.getItem('cartId')}`, {
      method: 'DELETE',
    })
      .then(response => response.json())
      .then(result => console.log("result"))
      .catch(error => console.log("Error: ", error));
  }

  return (
    <div className="Checkout">
      <div className="Shipping-Info-Checkout">
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
      <div className="Card-Info-Checkout">
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
      <div className="cart-info">
        Subtotal: {subtotal} Tax: {tax} Total: {total}
        <br />
        <button className="button-smaller" onClick={checkout}>Check Out</button> or{" "}
        <Link to="/products" className="button-smaller">Edit Cart</Link>
      </div>
    </div>
  );
}
