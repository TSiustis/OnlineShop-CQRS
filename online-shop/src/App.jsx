import HomePage from "./pages/HomePage";
import {
  BrowserRouter,
  Routes, 
  Route,
} from "react-router-dom";
import React from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import ProductList from "./pages/ProductListPage";
import ProductPage from "./pages/ProductPage";
import Layout from "./components/Layout";
function App() {
  return (
    <>
      <BrowserRouter>
        <Layout>
          <Routes>
            <Route path ='/product-list' element = {<ProductList/>}/>
            <Route path ='/product/:id' element = {<ProductPage/>}/>
            <Route
              path="/search/:searchQuery/page/:pageNumber"
              element={<HomePage />}
            />
            <Route path="/search/:searchQuery" element={<HomePage />} />
            <Route index path ='/' element = {<HomePage/>}/>
          </Routes>
        </Layout>
        </BrowserRouter>
    </>
  )
}

export default App
