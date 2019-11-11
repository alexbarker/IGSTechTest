using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IGSTechTest.Contracts.V1;
using IGSTechTest.Contracts.V1.Requests;
using IGSTechTest.Contracts.V1.Responses;
using IGSTechTest.Domain;
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
        public IActionResult Get([FromRoute]int productId)
        {
            var product = _productService.GetProductById(productId);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPut(ApiRoutes.Products.Update)]
        public IActionResult Update([FromRoute]int productId, [FromBody] UpdateProductRequest request)
        {
            var product = new Product
            {
                Id = productId,
               // ProductCode = request.ProductCode,
                Name = request.Name,
                Price = request.Price
            };

            var updated = _productService.UpdateProduct(product);

            if(updated)
                return Ok(product);

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Products.Delete)]
        public IActionResult Delete([FromRoute] int productId)
        {
            var deleted = _productService.DeleteProduct(productId);

            if(deleted)
                return NoContent();

            return NotFound();
        }


        [HttpPost(ApiRoutes.Products.Create)]
        public IActionResult Create([FromBody] CreateProductRequest productRequest)
        {
            int g =  _productService.CountProducts() + 1;

            var product = new Product
            {
                Id = g,
                Name = productRequest.Name,
                Price = productRequest.Price
            };

            _productService.GetProducts().Add(product);

                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                var locationUri = baseUrl + "/" + ApiRoutes.Products.Get.Replace("{productId}", product.Id.ToString());

                var response = new ProductResponse { Id = product.Id, Name = product.Name, Price = product.Price };

            return Created(locationUri, response);
        }
    }
}
