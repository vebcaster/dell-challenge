using DellChallenge.D2.Web.Models;
using System.Collections.Generic;

namespace DellChallenge.D2.Web.Services
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetAll();
        ProductModel Add(NewProductModel newProduct);
        ProductModel Get(string id);
        void Update(string id, NewProductModel newProduct);
        void Delete(string id);
    }
}