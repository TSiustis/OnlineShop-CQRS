import React, { useState, useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
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
import { listProductDetails } from "../redux/actions/productActions";
import Loading from "../components/Loading";
import "./ProductPage.css";

function ProductPage() {
    let navigate = useNavigate();
    const dispatch = useDispatch();
    let params = useParams();
    
    const [stock, setStock] = useState(0);
    const productDetails = useSelector((state) => state.productDetails);
    
    const { product, loading, error } = productDetails;
  console.log(product);
    useEffect(() => {
      if (error) {
        navigate("/");
      }
      dispatch(listProductDetails(params.id));
    }, [dispatch, params.id]);
  

   
    return (
      <>
       {loading ? (
        <Loading />
      ) : error ? (
        <Message variant="danger"></Message>
      ) : (
        product && (
          <>
                <Row>
                <Col md={4}>
                  <Image src={product.imageUri} alt={product.name} fluid />
                </Col>

                <Col md={5} className="my-auto">
                  <h3 className="my-3">{product.name}</h3>
                  <ListGroup variant="flush">
                    <ListGroup.Item>
                      <h4>Price: <span className="text-primary">${product.price}</span></h4>
                    </ListGroup.Item>
                    <ListGroup.Item>
                      <h4>Description:</h4>
                      <p>{product.description}</p>
                    </ListGroup.Item>
                  </ListGroup>
                </Col>

                <Col md={3}>
                  <Card className="my-3 p-3">
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
                            {product.stock > 0 ? <span className="text-success">In stock</span> : <span className="text-danger">Out of stock</span>}
                          </Col>
                        </Row>
                      </ListGroup.Item>
                      {product.stock > 0 && (
                        <ListGroup.Item>
                          <Row>
                            <Col>Quantity</Col>
                            <Col>
                              <FormControl as="select" value={stock} onChange={(e) => setStock(e.target.value)}>
                                {[...Array(product.stock).keys()].map((x) => (
                                  <option value={x + 1} key={x + 1}>
                                    {x + 1}
                                  </option>
                                ))}
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
                          disabled={product.stock === 0}
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
  );
}

export default ProductPage;