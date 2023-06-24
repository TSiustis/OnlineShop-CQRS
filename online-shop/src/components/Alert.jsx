import React from "react";
import { Alert } from "react-bootstrap";

const Alert = ({ variant, children }) => {
  return <Alert variant={variant}>{children}</Alert>;
};

export default Alert;