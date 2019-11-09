using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGSTechTest.Contracts.V1;
using IGSTechTest.Contracts.V1.Requests;
using IGSTechTest.Contracts.V1.Responses;
using IGSTechTest.Domain;
using IGSTechTest.Services;

namespace IGSTechTest.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProductById(Guid productId);

        bool UpdateProduct(Product productToUpdate);

        bool DeleteProduct(Guid productId);
    }
}
