import * as actions from "../constants/productConstants";

export const productListReducer = (state = { products: [] }, action) => {
    console.log('State', state);
    console.log('Action', action)
    switch (action.type) {
      case actions.PRODUCT_LIST_REQUEST:
        return {
            
          ...state,
        };
      case actions.PRODUCT_LIST_SUCCESS:
        return {
          ...state,
          products: action.payload.data,
          pageNumber: action.payload.pageNumber,
          pageSize: action.payload.pageSize,
        };
      case actions.PRODUCT_LIST_FAIL:
        return {
          ...state,
          error: action.payload,
        };
      default:
        return state;
    }
  };

export const productDetailsReducer = (
  state = { product: {} },
  action
) => {
  switch (action.type) {
    
    case actions.PRODUCT_DETAILS_REQUEST:
        
      return {
        ...state,
        loading: true,
      };
    case actions.PRODUCT_DETAILS_SUCCESS:
        console.log(state);
        console.log(action);
      return {
        ...state,
        loading: false,
        product: state,
      };
    case actions.PRODUCT_DETAILS_FAIL:
      return {
        ...state,
        loading: false,
        error: action.payload,
      };
    case actions.PRODUCT_DETAILS_RESET:
      return {};
    default:
      return state;
  }
};

export const productDeleteReducer = (state = {}, action) => {
  switch (action.type) {
    case actions.PRODUCT_DELETE_REQUEST:
      return {
        ...state,
        loading: true,
      };
    case actions.PRODUCT_DELETE_SUCCESS:
      return {
        ...state,
        loading: false,
        success: true,
      };
    case actions.PRODUCT_DELETE_FAIL:
      return {
        ...state,
        loading: false,
        error: action.payload,
      };
    default:
      return state;
  }
};

export const productCreateReducer = (state = {}, action) => {
  switch (action.type) {
    case actions.PRODUCT_CREATE_REQUEST:
      return {
        ...state,
        loading: true,
      };
    case actions.PRODUCT_CREATE_SUCCESS:
      return {
        ...state,
        loading: false,
        success: true,
      };
    case actions.PRODUCT_CREATE_FAIL:
      return {
        ...state,
        loading: false,
        error: action.payload,
      };
    default:
      return state;
  }
};

export const productUpdateReducer = (state = {}, action) => {
  switch (action.type) {
    case actions.PRODUCT_UPDATE_REQUEST:
      return {
        ...state,
        loading: true,
      };
    case actions.PRODUCT_UPDATE_SUCCESS:
      return {
        ...state,
        loading: false,
        success: true,
        error: null,
      };
    case actions.PRODUCT_UPDATE_FAIL:
      return {
        ...state,
        loading: false,
        error: action.payload,
      };
    case actions.PRODUCT_UPDATE_RESET: {
      return {};
    }
    default:
      return state;
  }
};
