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
import ProductPage from './Pages/ProductPage';
function App() {
  return (
    <>
      <BrowserRouter>
        <CustomNav/>
          <Routes>
            <Route path ='/'exact element = {<HomePage/>}/>
            <Route path ='/product-list' element = {<ProductList/>}/>
            <Route path ='/product/:id' element = {<ProductPage/>}/>
          </Routes>
        </BrowserRouter>
    </>
  )
}

export default App
