using DellChallenge.D1.Api.Dto;
using System.Collections.Generic;

namespace DellChallenge.D1.Api.Dal
{
    public interface IProductsService
    {
        IEnumerable<ProductDto> GetAll();
        ProductDto Get(string id);
        ProductDto Add(NewProductDto newProduct);
        void Update(string id, NewProductDto product);
        void Delete(string id);
    }
}
