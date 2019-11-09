using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using IGSTechTest.Cache;
using IGSTechTest.Contracts.V1;
using IGSTechTest.Contracts.V1.Requests;
//using IGSTechTest.Contracts.V1.Requests.Queries;
using IGSTechTest.Contracts.V1.Responses;
using IGSTechTest.Domain;
//using IGSTechTest.Extensions;
//using IGSTechTest.Helpers;
using IGSTechTest.Services;

namespace IGSTechTest.Controllers.V1
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(ApiRoutes.Products.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetProducts());
        }

        [HttpGet(ApiRoutes.Products.Get)]
        public IActionResult Get([FromRoute]Guid productId)
        {
            var product = _productService.GetProductById(productId);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost(ApiRoutes.Products.Create)]
        public IActionResult Create([FromBody] CreateProductRequest productRequest)
        {
            var product = new Product { Id = productRequest.Id };

            if (product.Id != Guid.Empty)
                product.Id = Guid.NewGuid();
            
            _productService.GetProducts().Add(product);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Products.Get.Replace("{productId}", product.Id.ToString());

            var response = new ProductResponse { Id = product.Id };
            
            return Created(locationUri, response);
        }
    }
}
