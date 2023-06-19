import axios from "axios";
const baseURL = "https://localhost:5001/api";

const apiClient = axios.create({
  baseURL: baseURL,
  headers: {
    "Content-Type": "application/json",
  },
});

const getAll = async (pageNumber, pageSize) => {
  var response;
  try {
    console.log(`page number: ${pageNumber}, ${pageSize}`);
    response = await apiClient.get(`/products?pageNumber=${pageNumber}&pageSize=${pageSize}`);
    console.log(response);
  } catch (error) {
    console.error(error);
  }
  
  return response.data;
};


const getById = async (id) => {
  var response;
  try{
    response = await apiClient.get(`/products/${id}`);
  }catch(error)
  {
    console.error(error);
  }
  
  return response.data;
}


  const post = (data) => apiClient.post("/products", data)
    .then(response =>{
      console.log(response.data);
    })
    .catch(error =>
      console.log(error));

  const put = (data) => apiClient.put("/products", data)
    .then(response =>{
  console.log(response.data);
  })
    .catch(error =>
  console.log(error));

const remove = (id) =>  apiClient.delete("/products/" + id)
.then(response => {
  console.log(response);
})
.catch(error =>{
  console.log(error)});

  const productService = {
    getAll,
    getById,
    post,
    put,
    remove
  };
export default productService;