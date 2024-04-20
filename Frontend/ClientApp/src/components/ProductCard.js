/* cards are encapsulated in a product card component */
const ProductCard = ({ product, handleAddToCart }) => {
    return (
        <div className="product-card">
            <img src={product.image} alt={product.name} />
            <h3>{product.name}</h3>
            <p>Price: ${product.price}</p>
            {/* Additional UI elements and interactions */}
            <button onClick={() => handleAddToCart(product)}>Add to Cart</button>
        </div>
    );
};

export default ProductCard;