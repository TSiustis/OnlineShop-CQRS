import * as actions from "../constants/productConstants.js";
import axios from "axios";
import productService from "../../api/productService.jsx";

export const listProduct =
  (searchQuery = "", pageNumber = 1, pageSize = 5) =>
  async (dispatch) => {
    try {
        dispatch({ type: actions.PRODUCT_LIST_REQUEST });

        const { data } = await axios.get(
            `https://localhost:5001/api/products?searchQuery=${searchQuery}&pageNumber=${pageNumber}&pageSize=${pageSize}`
          );
        dispatch({ type: actions.PRODUCT_LIST_SUCCESS, payload: data });
    } catch (error) {
        dispatch({
            type: actions.PRODUCT_LIST_FAIL,
            payload:
            error.response && error.response.data.message
                ? error.response.data.message
                : error.message,
        });
    }
  };

export const listProductDetails = (id) => async (dispatch) => {
  try {
    dispatch({ type: actions.PRODUCT_DETAILS_RESET });
    dispatch({ type: actions.PRODUCT_DETAILS_REQUEST });

    const { data } = await axios.get(
        `https://localhost:5001/api/products/${id}`);
    dispatch({ type: actions.PRODUCT_DETAILS_SUCCESS, payload: data });
  } catch (error) {
    dispatch({
      type: actions.PRODUCT_DETAILS_FAIL,
      payload:
        error.response && error.response.data.message
          ? error.response.data.message
          : error.message,
    });
  }
};

export const deleteProduct = (id) => async (dispatch, getState) => {
  try {
    dispatch({ type: actions.PRODUCT_DELETE_REQUEST });

    await productService.deleteProduct(id);

    dispatch({ type: actions.PRODUCT_DELETE_SUCCESS });
  } catch (error) {
    const message =
      error.response && error.response.data.message
        ? error.response.data.message
        : error.message;
    dispatch({
      type: actions.PRODUCT_DELETE_FAIL,
      payload: message,
    });
  }
};

export const createProduct = (dataProduct) => async (dispatch, getState) => {
  try {
    dispatch({ type: actions.PRODUCT_CREATE_REQUEST });

    await productService.post(dataProduct);

    dispatch({ type: actions.PRODUCT_CREATE_SUCCESS });
  } catch (error) {
    const message =
      error.response && error.response.data.message
        ? error.response.data.message
        : error.message;
    dispatch({
      type: actions.PRODUCT_CREATE_FAIL,
      payload: message,
    });
  }
};

export const updateProduct = (dataProduct) => async (dispatch, getState) => {
  try {
    dispatch({ type: actions.PRODUCT_UPDATE_REQUEST });

    await productService.put(dataProduct);

    dispatch({ type: actions.PRODUCT_UPDATE_SUCCESS });
    dispatch({ type: actions.PRODUCT_UPDATE_RESET });
  } catch (error) {
    const message =
      error.response && error.response.data.message
        ? error.response.data.message
        : error.message;
    dispatch({
      type: actions.PRODUCT_UPDATE_FAIL,
      payload: message,
    });
  }
};
