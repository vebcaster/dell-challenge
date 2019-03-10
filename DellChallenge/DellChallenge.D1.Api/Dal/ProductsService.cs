using System;
using System.Collections.Generic;
using System.Linq;
using DellChallenge.D1.Api.Dto;

namespace DellChallenge.D1.Api.Dal
{
    public class ProductsService : IProductsService
    {
        private readonly ProductsContext _context;

        public ProductsService(ProductsContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return _context.Products.Select(p => MapToDto(p));
        }

        public ProductDto Get(string id)
        {
            var selectedProducts = _context.Products.
                Where(p => p.Id == id);

            if (selectedProducts.Any())
                return MapToDto(selectedProducts.First());

            return null;
        }

        public ProductDto Add(NewProductDto newProduct)
        {
            var product = MapToData(newProduct);
            _context.Products.Add(product);
            _context.SaveChanges();

            var addedDto = MapToDto(product);
            return addedDto;
        }

        public void Update(string id, NewProductDto product)
        {
            var selectedProducts = _context.Products.Where(p => p.Id == id);

            if (!selectedProducts.Any())
                throw new ArgumentOutOfRangeException("Product to edit was not found");

            var productToEdit = selectedProducts.First();
            productToEdit.Category = product.Category;
            productToEdit.Name = product.Name;
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var selectedProducts = _context.Products.Where(p => p.Id == id);

            if (!selectedProducts.Any())
                throw new ArgumentOutOfRangeException("Product to delete was not found");

            var productToDelete = selectedProducts.First();
            _context.Products.Remove(productToDelete);
            _context.SaveChanges();
        }

        private Product MapToData(NewProductDto newProduct)
        {
            return new Product
            {
                Category = newProduct.Category,
                Name = newProduct.Name
            };
        }

        private ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category
            };
        }
    }
}
