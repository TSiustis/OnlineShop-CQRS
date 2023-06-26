import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Form, Button } from "react-bootstrap";

const SearchBox = () => {
  let navigate = useNavigate();
  const [searchQuery, setSearchQuery] = useState("");

  const submitHandler = (e) => {
    e.preventDefault();
    console.log(`searchQuery: ${searchQuery}`);
    if (searchQuery.trim()) {
      navigate(`/search/${searchQuery}`);
    } else {
      navigate("/");
    }
  };

  return (
    <Form onSubmit={submitHandler} className="d-flex">
      <Form.Control
        type="text"
        name="searchQuery"
        placeholder="Search products ..."
        onChange={(e) => setSearchQuery(e.target.value)}
        className="mr-sm-2 ml-sm-5"
      ></Form.Control>
      <Button variant="info" type="submit" className="p-2">
        Search
      </Button>
    </Form>
  );
};

export default SearchBox;
