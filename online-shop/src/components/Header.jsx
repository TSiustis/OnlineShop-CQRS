import React from 'react';
import {Nav, Navbar } from 'react-bootstrap';
import {LinkContainer} from 'react-router-bootstrap';
import {Link} from 'react-router-dom';
import "./Header.css";

function Header()
{
    return(
      <div className='container'>
        <Navbar bg="light" className='w-100'>
        <Navbar.Brand href="#">My Online Shop</Navbar.Brand>
        <Navbar.Toggle aria-controls="navbar-nav" />
        <Navbar.Collapse id="navbar-nav">
          <Nav className="me-auto">
            <Link to="/">Home</Link>
            <Link to="/product-list">Shop</Link>
          </Nav>
          <Nav className = "justify-content-end">
          <LinkContainer to="/cart">
              <Nav.Link>
                <i className="fas fa-shopping-cart"></i> Cart
              </Nav.Link>
            </LinkContainer>
            <Nav.Link href="#">Login</Nav.Link>
            <Nav.Link href="#">Sign up</Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
      </div>
    );

}
export default Header;