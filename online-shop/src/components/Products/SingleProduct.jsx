import PropTypes from 'prop-types';

function SingleProduct(props) {
    const {productItem} = props;
    return (
        <div className = "product-item">
            <div className = "product_item">
                <img src = {productItem.imagePath} alt = "" className = "img-fluid" />
            </div>

            <div className = "product_info">
                <h6 className = "product_name">
                    <div>{productItem.price}</div>
                </h6>
                <div className = "product_price">
                    {productItem.price}
                    <span>{(parseFloat(productItem.price) + 30).toFixed(2)}</span>
                </div>
            </div>
            <div className="add_to_cart_button"
            onClick = {() => props.addToCart(productItem._id)}>
                <div style={{ color: "#ffffff" }}>add to cart</div>
            </div>
        </div>
    )
}

SingleProduct.propTypes = {
    productItem : PropTypes.object,
    imagePath: PropTypes.string,
    price: PropTypes.number,
    addToCart: PropTypes.object,
    _id: PropTypes.number,
  };
export default SingleProduct;