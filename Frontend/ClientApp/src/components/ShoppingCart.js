/* Allows users to add items to their shopping cart */
const ShoppingCart = ({ cartItems, handleCheckout }) => {
    return (
        <div className="shopping-cart">
            <h3>Shopping Cart</h3>
            {cartItems.map(item => (
                <CartItem key={item.id} item={item} />
            ))}
            <button onClick={handleCheckout}>Checkout</button>
        </div>
    );
};