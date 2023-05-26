import React, { useState, useEffect, useCallback } from 'react';
import {useParams } from "react-router-dom";
import productService from '../../api/productService';

const ProductDetails = function () {
    const { id } = useParams();
    console.log(id);
    const [loading, setLoading] = useState(false);
    const [product, setProduct] = useState(null)

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
    
    if(!loading)
    {
        return <div>Loading...</div>
    }


    return (
        <div className="container-fluid">
            <div className ="row">
                                    {/* <img src={product.image} /> */}
                            
                        <div className="details col-md-6">
                            <h3 className="product-title">{product.name}</h3>

                            {/* <h4 className="price">price: <span>$ {product.price}</span></h4>
                            <div className="action">
                                <button onClick={addBasket} className="add-to-cart btn btn-default" type="button">Add to cart</button>
                            </div> */}
                        </div>
                        <div className='d-flex align-items-center'>
                        <div className="input-group quantity mr-3">
                            <div className="input-group-btn">
                                <button className="btn btn-primary btn-minus">
                                    <i className="fa fa-minus"></i>
                                </button>
                            </div>
                        <input readOnly type="text" class="form-control bg-secondary border-0 text-center" value="1"/>
                            <div className="input-group-btn">
                                <button className="btn btn-primary btn-plus">
                                    <i className="fa fa-plus"></i>
                                </button>
                            </div>
                        </div>
                        <button className="btn btn-primary px-3"><i class="fa fa-shopping-cart mr-1"></i> Add To
                            Cart</button>
                            </div>
                        </div>
                        </div>
    )
}
export default ProductDetails;