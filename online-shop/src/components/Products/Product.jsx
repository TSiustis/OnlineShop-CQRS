import PropTypes from 'prop-types';
import React from 'react';
import { Link } from 'react-router-dom';

function Product(props) {
    return (
        <div className="col-md-3">
            <div className = "product-item">
                {/* <div className = "product_image">
                    <img src = {productItem.imagePath} alt = "" className = "img-fluid" />
                </div> */}

                <div className = "product_info">
                    <h6 className = "product_name">
                        <div>{props.product.name}</div>
                    </h6>
                    {/* <div className = "product_price">
                        {productItem.price}
                        <span>{(parseFloat(productItem.price) + 30).toFixed(2)}</span>
                    </div> */}
                </div>
                <div className="add_to_cart_button"
                onClick = {() => props.addToCart(productItem._id)}>
                    <div style={{ color: "#ffffff" }}>add to cart</div>
                </div>
                <Link to={props.link} className="btn btn-primary">Details</Link>
            </div>
        </div>
    )
}

Product.propTypes = {
    productItem : PropTypes.object,
    imagePath: PropTypes.string,
    price: PropTypes.number,
    addToCart: PropTypes.object,
    _id: PropTypes.number,
  };
export default Product;