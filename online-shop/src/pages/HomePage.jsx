import React, {useState, useEffect} from "react";
import Loading from "../components/Loading";
import Product from "../components/Products/Product";
import {Row, Col} from "react-bootstrap";
import productService from "../api/productService";

function HomePage(){
    const [productList, setProductList] = useState([]);
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        async function fetchData() {
            var response = await productService.getAll(1,5);
            console.log(response);
            return response;
        }

        fetchData()
        .then((response) => {
            console.log(response);
            setProductList(response.data);
            setLoading(true);
        })
        .catch(error => console.error(error));
    }, []);

    return(
        <>
        <h3>Latest Products</h3>
        <Row>
            {!loading ? (
            <Loading />
            ) : (
                productList.map((product, index) => (
                <Col sm={12} md={6} lg={4} xl={3}>
                <Product product={product} key={index} />
                </Col>
            ))
            )}
        </Row>
        </>
    );
}

export default HomePage;