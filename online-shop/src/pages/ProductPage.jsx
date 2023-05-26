import React, { useState, useEffect } from "react";
import { useParams, Link, useNavigate } from "react-router-dom";
import {
  Row,
  Col,
  Image,
  ListGroup,
  Button,
  Card,
  FormControl,
  Form,
} from "react-bootstrap";
import productService from "../api/productService";

function ProductPage() {
    const [stock, setStock] = useState(0);
    const [product, setProduct] = useState({});
    const [loading, setLoading] = useState(false);
    let {id} = useParams();

    useEffect(() => {
        async function fetchData() {
            var response = await productService.getById(id);
            return response;
        }
        fetchData()
        .then((data) => {
            setProduct(data);
            setLoading(true);
        })
        .catch(error => console.error(error));
    }, []);

    
    return (
        <>
        {!loading ?
    
         (<div>Loading...</div>
         )
         :
    (product && (
          <>
            <Row>
              <Col md={4}>
                <Image src={product.image} alt={product.name} fluid />
              </Col>
              <Col md={5}>
                <h3>{product.name}</h3>
                <ListGroup variant="flush">
                  <ListGroup.Item>Price: ${product.price}</ListGroup.Item>
                  <ListGroup.Item>
                    Description: {product.description}
                  </ListGroup.Item>
                </ListGroup>
              </Col>
              <Col md={3}>
                <Card>
                  <ListGroup variant="flush">
                    <ListGroup.Item>
                      <Row>
                        <Col>Price:</Col>
                        <Col>
                          <strong>${product.price}</strong>
                        </Col>
                      </Row>
                    </ListGroup.Item>
                    <ListGroup.Item>
                      <Row>
                        <Col>Status:</Col>
                        <Col>
                          {product.countInStock > 0
                            ? `In stock`
                            : `Out of stock`}
                        </Col>
                      </Row>
                    </ListGroup.Item>
                    {product.countInStock > 0 && (
                      <ListGroup.Item>
                        <Row>
                          <Col>Qty</Col>
                          <Col>
                            <FormControl
                              as="select"
                              value={qty}
                              onChange={(e) => setQty(e.target.value)}
                            >
                              {[...Array(product.countInStock).keys()].map(
                                (x) => (
                                  <option value={x + 1} key={x + 1}>
                                    {x + 1}
                                  </option>
                                )
                              )}
                            </FormControl>
                          </Col>
                        </Row>
                      </ListGroup.Item>
                    )}
                    <ListGroup.Item>
                      <Button
                       // onClick={addToCartHandler}
                        className="btn btn-primary d-block w-100"
                        type="button"
                        disabled={product.countInStock === 0}
                      >
                        Add to cart
                      </Button>
                    </ListGroup.Item>
                  </ListGroup>
                </Card>
              </Col>
            </Row>
            </>
            )
    )}
    </>
    )         
}
export default ProductPage;