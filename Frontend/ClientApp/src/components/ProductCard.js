/* cards are encapsulated in a product card component */
const ProductCard = ({ product }) => {
    return (
        <div className="product-card">
            <img src={product.image} alt={product.title} />
            <h3>{product.title}</h3>
            <p>{product.price}</p>
            {/* Additional UI elements and interactions */}
        </div>
    );
};