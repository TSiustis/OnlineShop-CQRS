import React from 'react';
import {Nav, Navbar } from 'react-bootstrap';
import {Link} from 'react-router-dom';

function CustomNav()
{
    return(
        <Navbar bg="light">
        <Navbar.Brand href="#">My Online Shop</Navbar.Brand>
        <Navbar.Toggle aria-controls="navbar-nav" />
        <Navbar.Collapse id="navbar-nav">
          <Nav className="me-auto">
            <Link to="/">Home</Link>
            <Link to="/productList">Shop</Link>
          </Nav>
          <Nav className = "justify-content-end">
            <Nav.Link href="#">Login</Nav.Link>
            <Nav.Link href="#">Sign up</Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
}
export default CustomNav;