using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGSTechTest.Domain;
using Microsoft.AspNetCore.Mvc;
using IGSTechTest.Contracts;
using IGSTechTest.Contracts.V1;

namespace IGSTechTest.Controllers.V1
{
    public class ProductsController : Controller
    {
        private List<Product> _products;

        public ProductsController()
        {
            _products = new List<Product>();
            for (var i = 0; i < 5; i++)
            {
                _products.Add(new Product { Id = Guid.NewGuid().ToString() });
            }
        }

        [HttpGet(ApiRoutes.Products.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_products);
        }
    }
}
