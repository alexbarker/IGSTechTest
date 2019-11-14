using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGSTechTest.Contracts.V1;
using IGSTechTest.Contracts.V1.Requests;
using IGSTechTest.Contracts.V1.Responses;
using IGSTechTest.Domain;
using IGSTechTest.Services;
using Microsoft.EntityFrameworkCore;
using IGSTechTest.Data;
using IGSTechTest.Installers;
using IGSTechTest.Controllers;

namespace IGSTechTest.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products;

        public ProductService()
        {
            _products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = $"Lavender heart",
                    Price = $"9.25"
                },
                new Product
                {
                    Id = 2,
                    Name = $"Personalised cufflinks",
                    Price = $"45.00"
                },
                new Product
                {
                    Id = 3,
                    Name = $"Kids T-shirt",
                    Price = $"19.95"
                }
            };

        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public bool CreateProduct(Product productToCreate)
        {
            var exists = GetProductById(productToCreate.Id) != null;

            if (!exists)
                return false;

            var index = _products.FindIndex(x => x.Id == productToCreate.Id);
            _products[index] = productToCreate;
            return true;
        }


        public int CountProducts()
        {
            return _products.Count;
        }

        public Product GetProductById(int productId)
        {
            return _products.SingleOrDefault(x => x.Id == productId);
        }


        public bool UpdateProduct(Product productToUpdate)
        {

            var exists = GetProductById(productToUpdate.Id) != null;

            if (!exists)
                return false;

            var index = _products.FindIndex(x => x.Id == productToUpdate.Id);
                _products[index] = productToUpdate;
                return true;

        }

        public bool DeleteProduct(int productId)
        {
            var product = GetProductById(productId);

            if (product == null)
                return false;

            _products.Remove(product);
            return true;
        }
    }
}
