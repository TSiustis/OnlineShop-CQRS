import { Carousel, Nav, Navbar, NavDropdown } from 'react-bootstrap';
import React, {Component} from 'react';

function HomePage() {
  return (
    <div>
      <Navbar bg="light">
        <Navbar.Brand href="#">My Online Shop</Navbar.Brand>
        <Navbar.Toggle aria-controls="navbar-nav" />
        <Navbar.Collapse id="navbar-nav">
          <Nav className="me-auto">
            <Nav.Link href="#">Home</Nav.Link>
            <Nav.Link href="#">Shop</Nav.Link>
            <NavDropdown title="Categories" id="nav-dropdown">
              <NavDropdown.Item href="#">Electronics</NavDropdown.Item>
              <NavDropdown.Item href="#">Clothing</NavDropdown.Item>
              <NavDropdown.Item href="#">Home &amp; Garden</NavDropdown.Item>
            </NavDropdown>
          </Nav>
          <Nav className = "justify-content-end">
            <Nav.Link href="#">Login</Nav.Link>
            <Nav.Link href="#">Sign up</Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Navbar>

      <Carousel>
        <Carousel.Item>
          <img
            className="d-block w-100"
            src="https://via.placeholder.com/1920x600?text=Carousel+1"
            alt="First slide"
          />
          <Carousel.Caption>
            <h3>Featured Product</h3>
            <p>Check out our latest and greatest item!</p>
          </Carousel.Caption>
        </Carousel.Item>
        <Carousel.Item>
          <img
            className="d-block w-100"
            src="https://via.placeholder.com/1920x600?text=Carousel+2"
            alt="Second slide"
          />
          <Carousel.Caption>
            <h3>New Arrivals</h3>
            <p>Shop our newest products today!</p>
          </Carousel.Caption>
        </Carousel.Item>
      </Carousel>

      <div>
        <h1>Welcome to our E-commerce Store</h1>
        <p>
          Browse our selection of high-quality products, and add your favorites to your cart. We offer fast, reliable shipping and a 100% satisfaction guarantee.
        </p>
        <button>Shop Now</button>
      </div>

      <footer>
        <p>&copy; 2023 My E-commerce Store. All rights reserved.</p>
      </footer>
    </div>
  );
}

export default HomePage;
