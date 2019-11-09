using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGSTechTest.Contracts.V1;
using IGSTechTest.Contracts.V1.Requests;
//using IGSTechTest.Contracts.V1.Requests.Queries;
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
            _products = new List<Product>();
            for (var i = 0; i < 5; i++)
            {
                _products.Add(new Product
                {
                    Id = Guid.NewGuid(),
                    Name = $"Product Name {i}"
                });
            }
        }

        public List<Product> GetProducts()
        {
            return _products;
        }
        public Product GetProductById(Guid productId)
        {
            return _products.SingleOrDefault(x => x.Id == productId);
        }
    }
}
