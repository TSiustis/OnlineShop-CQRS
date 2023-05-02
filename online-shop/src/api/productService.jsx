import axios from "axios";
const baseURL = "http://localhost:5001/api";

const apiClient = axios.create({
  baseURL: baseURL,
  headers: {
    "Content-Type": "application/json",
  },
});

const getAll = apiClient.get('/products/' )
  .then(response => {
    response.data;
  })
  .catch(error => {
    console.error(error);
  });

const getById = (id) => apiClient.get('/products/' + {id} )
  .then(response => {
    response.data;
  })
  .catch(error => {
    console.error(error);
  });

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

const remove = (id) =>  apiClient.delete("/product/" + id)
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