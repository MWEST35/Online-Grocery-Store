/* Allows users to search based on categories */
const ProductFilter = ({ categories, handleFilterChange }) => {
    return (
        <div className="product-filter">
            <label>Filter by Category:</label>
            <select onChange={handleFilterChange}>
                {categories.map(category => (
                    <option key={category} value={category}>
                        {category}
                    </option>
                ))}
            </select>
        </div>
    );
};

export default ProductFilter;