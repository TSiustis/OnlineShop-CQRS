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
    const searchQuery = params.searchQuery;

    const dispatch = useDispatch();

    const productList = useSelector((state) => state.productList);
    const { products, loading, error, pageNo, pageS } = productList;


    useEffect(() => {
        dispatch(listProduct(searchQuery, pageNumber, pageSize));
      },[dispatch, pageSize, pageNumber]);

    return(
        <>
        <h3>Latest Products</h3>
        <Row>
            {loading ? (
            <Loading />
            ) :
             (
            products.map((product, index) => (
                <Col sm={12} md={6} lg={4} xl={3}>
                <Product product={product} key={index} />
                </Col>
            ))
            )}
        </Row>
        <PaginatedList pageNumber={pageNo} pageSize={pageS} searchQuery={searchQuery ? searchQuery : ""} />
        </>
    );
}

export default HomePage;