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

    console.log(productList);
    useEffect(() => {
        dispatch(listProduct(pageNumber, pageSize));
      },[dispatch, pageSize, pageNumber]);
    
    if(!loading)
    {
        return <div>Loading...</div>
    }
    
    return (
        <>
        <div className="product-container container-fluid">
            <div className="row">
                <div class="d-flex align-items-center justify-content-between mb-4">
                    <div>
                        <button class="btn btn-sm btn-light"><i class="fa fa-th-large"></i></button>
                        <button class="btn btn-sm btn-light ml-2"><i class="fa fa-bars"></i></button>
                    </div>
                </div>

                <div className="row">
                    {products.map((product) => {
                        const link = `/details/${product.id}`;
                        return (
                            <div className="col-md-4"> 
                                <Product key={product.id} link={link} product={product} />
                            </div>
                        );
                    })}
                </div>
            </div>
        </div>
        <PaginatedList pageNumber={pageN} pageSize={pageS} />
        </>
    )
}
export default ProductList;
