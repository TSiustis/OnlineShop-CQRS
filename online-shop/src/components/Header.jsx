import "./Header.css";
import React from "react";
import { LinkContainer } from "react-router-bootstrap";
import { Container, Navbar, Nav } from "react-bootstrap";
import SearchBox from "./SearchBox";

function Header() {

    return (
      <header>
        <Navbar bg="primary">
          <Container>
            <LinkContainer to="/">
              <Navbar.Brand>OnlineShop</Navbar.Brand>
            </LinkContainer>

            <Nav className="ml-auto">
              <LinkContainer to="/cart">
                <Nav.Link>
                  <i className="fas fa-shopping-cart"></i> Cart
                </Nav.Link>
              </LinkContainer>
              <SearchBox />
              {/* {userInfo ? (
                <NavDropdown title={userInfo.name} id="username">
                  <LinkContainer to="profile">
                    <NavDropdown.Item>Profile</NavDropdown.Item>
                  </LinkContainer>
                  <NavDropdown.Item onClick={handleLogout}>
                    Logout
                  </NavDropdown.Item>
                </NavDropdown>
              ) : ( */}
                <LinkContainer to="/login">
                  <Nav.Link>
                    <i className="fas fa-user"></i> SignIn
                  </Nav.Link>
                </LinkContainer>
              {/* )} */}
              {/* {userInfo && userInfo.isAdmin && (
                <NavDropdown title="admin" id="useradmin">
                  <LinkContainer to="/admin/users">
                    <NavDropdown.Item>Users</NavDropdown.Item>
                  </LinkContainer>
                  <LinkContainer to="/admin/products">
                    <NavDropdown.Item>Products</NavDropdown.Item>
                  </LinkContainer>
                  <LinkContainer to="/admin/orders">
                    <NavDropdown.Item>Orders</NavDropdown.Item>
                  </LinkContainer>
                </NavDropdown>
              )} */}
            </Nav>
          </Container>
        </Navbar>
      </header>
    );
        }
export default Header;