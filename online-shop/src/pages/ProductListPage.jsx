import React, {useState, useEffect} from 'react';
import Product  from '../components/Products/Product';
import { useDispatch, useSelector } from "react-redux";
import { useParams } from "react-router-dom";
import PaginatedList from '../components/PaginatedList';
import { listProduct } from '../redux/actions/productActions';

function ProductList()
{
    let params = useParams();
    const pageNumber = params.pageNumber || 1;
    const pageSize = params.pageSize || 10;
    console.log(pageNumber, pageSize);
    const dispatch = useDispatch();

    const [loading, setLoading] = useState(false);
    const productList = useSelector((state) => state.productList);
    const { products, pageN, pageS } = productList;

    useEffect(() => {
        dispatch(listProduct(pageNumber, pageSize));
      },[dispatch, pageSize, pageNumber]);
    
    if(!loading)
    {
        return <div>Loading...</div>
    }
    
    return (
        <>
        <Meta title="Clothshop | Home" />
        {/* {!keyword && <ProductCarousel />} */}
        <h3>Latest Products</h3>
        <Row>
          {loading ? (
            <Loading />
          ) : error ? (
            <Message variant="danger">{error}</Message>
          ) : (
            products.map((product, index) => (
              <Col sm={12} md={6} lg={4} xl={3}>
                <Product product={product} key={index} />
              </Col>
            ))
          )}
        </Row>
        <PaginatedList pageNumber={pageNumber} pageSize={pages} keyword={keyword ? keyword : ""} />
      </>
    )
}
export default ProductList;
