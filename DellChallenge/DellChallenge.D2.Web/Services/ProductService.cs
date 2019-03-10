using System.Collections.Generic;
using DellChallenge.D2.Web.Models;
using RestSharp;

namespace DellChallenge.D2.Web.Services
{
    public class ProductService : IProductService
    {
        private const string ProductApiEndPoint = "http://localhost:5000/api";  // in a production-ready app, should probably be read from config

        public ProductModel Add(NewProductModel newProduct)
        {
            var apiClient = new RestClient(ProductApiEndPoint);
            var apiRequest = new RestRequest("products", Method.POST, DataFormat.Json);
            apiRequest.AddJsonBody(newProduct);
            var apiResponse = apiClient.Execute<ProductModel>(apiRequest);
             return apiResponse.Data;
        }

        public IEnumerable<ProductModel> GetAll()
        {
            var apiClient = new RestClient(ProductApiEndPoint);
            var apiRequest = new RestRequest("products", Method.GET, DataFormat.Json);
            var apiResponse = apiClient.Execute<List<ProductModel>>(apiRequest);
            return apiResponse.Data;
        }

        public ProductModel Get(string id)
        {
            var apiClient = new RestClient(ProductApiEndPoint);
            var apiRequest = new RestRequest("products/{id}", Method.GET, DataFormat.Json);
            apiRequest.AddParameter("id", id, ParameterType.UrlSegment);
            var apiResponse = apiClient.Execute<ProductModel>(apiRequest);
            return apiResponse.Data;
        }

        public void Update(string id, NewProductModel newProduct)
        {
            var apiClient = new RestClient(ProductApiEndPoint);
            var apiRequest = new RestRequest("products/{id}", Method.PUT, DataFormat.Json);
            apiRequest.AddParameter("id", id, ParameterType.UrlSegment);
            apiRequest.AddJsonBody(newProduct);
            apiClient.Execute<ProductModel>(apiRequest);
        }

        public void Delete(string id)
        {
            var apiClient = new RestClient(ProductApiEndPoint);
            var apiRequest = new RestRequest("products/{id}", Method.DELETE, DataFormat.Json);
            apiRequest.AddParameter("id", id, ParameterType.UrlSegment);
            apiClient.Execute<ProductModel>(apiRequest);
        }
    }
}
