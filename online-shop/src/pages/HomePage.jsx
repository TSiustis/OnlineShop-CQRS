import React, {useState, useEffect} from "react";
import Loading from "../components/Loading";
import Product from "../components/Products/Product";
import {Row, Col} from "react-bootstrap";
import { useParams } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import PaginatedList from "../components/PaginatedList";
import { listProduct } from '../redux/actions/productActions';

function HomePage(){
    let params = useParams();
    const pageNumber = params.pageNumber;
    const pageSize = params.pageSize;
    const keyword = params.keyword;

    console.log(pageNumber, pageSize);
    const dispatch = useDispatch();

    const productList = useSelector((state) => state.productList);
    const { products, loading, error, pageNo, pageS } = productList;


    useEffect(() => {
        dispatch(listProduct(pageNumber, pageSize));
      },[dispatch, pageSize, pageNumber]);

    return(
        <>
        {/* {!keyword && <ProductCarousel />} */}
        <h3>Latest Products</h3>
        <Row>
            {loading ? (
            <Loading />
            ) : 
            // error ? (
            // <Message variant="danger">{error}</Message>
            // ) :
             (
            products.map((product, index) => (
                <Col sm={12} md={6} lg={4} xl={3}>
                <Product product={product} key={index} />
                </Col>
            ))
            )}
        </Row>
        <PaginatedList pageNumber={pageNo} pageSize={pageS} keyword={keyword ? keyword : ""} />
        </>
    );
}

export default HomePage;