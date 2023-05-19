import HomePage from './components/HomePage'
import {
  BrowserRouter,
  Routes, 
  Route,
} from "react-router-dom";
import React from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import ProductList from './components/Products/ProductList';
import CustomNav
 from './components/Nav';
function App() {
  return (
    <>
      <BrowserRouter>
        <CustomNav/>
          <Routes>
            <Route path ='/'exact element = {<HomePage/>}/>
            <Route path ='/productList' element = {<ProductList/>}/>
          </Routes>
        </BrowserRouter>
    </>
  )
}

export default App
