import CartItem from "./CartItem";
import { Link } from 'react-router-dom';

/* Allows users to add items to their shopping cart */
const ShoppingCart = ({ cartItems, handleCheckout }) => {
    return (
        <div className="shopping-cart">
            <h3>Shopping Cart</h3>
            {cartItems.map(item => (
                <CartItem key={item.id} item={item} />
            ))}
            <Link to="/Checkout">
                <button onClick={handleCheckout}>Checkout</button>
            </Link>
        </div>
    );
};

export default ShoppingCart;