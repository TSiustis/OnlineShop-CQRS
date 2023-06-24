import PropTypes from 'prop-types';
import './Product.css';
import React from 'react';
import { Link } from "react-router-dom";
import { Card } from "react-bootstrap";

function Product({product}) {
  console.log(product);
    return (
        <Card className="my-4 p-3 rounded">
      <Link to={`/product/${product.id}`}>
        <Card.Img src={product.imageUri} variant="top" />
      </Link>
      <Card.Body>
        <Link to={`/product/${product.id}`}>
          <Card.Title as="div">
            <strong>{product.name}</strong>
          </Card.Title>
        </Link>
        <Card.Text as="h6">
          <strong>{product.price}$</strong>
        </Card.Text>
      </Card.Body>
    </Card>
    )
}

Product.propTypes = {
    productItem : PropTypes.object,
    imagePath: PropTypes.string,
    name: PropTypes.string,
    price: PropTypes.number,
    _id: PropTypes.number,
  };
export default Product;