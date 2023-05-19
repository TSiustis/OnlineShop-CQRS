import React, {useState, useEffect} from 'react';
import Product  from './Product';
import productService from '../../api/productService';

function ProductList()
{
    const [loading, setLoading] = useState(false);
    const [products, setProducts] = useState({})

    useEffect(() => {
        async function fetchData() {
            var response = await productService.getAll();
            return response;
        }
        fetchData()
        .then((data) => {
            console.log(data);
            setProducts(data);
            setLoading(true);
        })
        .catch(error => console.error(error));
        console.log(products);
    }, []);
    if(!loading)
    {
        return <div>Loading...</div>
    }
    return (
        <div className="product-container">
            <div className="container">
                <div className="row">
                    {products.map((product) => {
                        const link = `/details/${product.id}`;
                        return <Product key = {product.id} link = {link} product = {product} />
                    })}
                </div>
            </div>
        </div>
    )
}
export default ProductList;
