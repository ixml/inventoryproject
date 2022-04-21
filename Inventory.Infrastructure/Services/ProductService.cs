using System;
using Inventory.Domain.Entities;
using Inventory.Domain.Models;
using Inventory.Domain.Repositories;
using Inventory.Domain.Services;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Inventory.Infrastructure.Services
{
    public class ProductService:IProductService
    {
        private IRepository<Product> productRepository;

        public ProductService(IRepository<Product> _productRepository)
        {
            productRepository = _productRepository;
        }

        public async Task ChangeProductStatus(ChangeProductStatusModel model)
        {
            var product = productRepository.Get(p => p.Id == model.ProductId).FirstOrDefault();

            if (product == null)
                throw new Exception("Product not found");

            product.ChangeStatus(model.Status);

            await productRepository.UpdateAsync(product);
        }

        public Task<List<ProductStatResponseModel>> GetProductStat()
        {
           

            var stat = productRepository.GetAll().AsQueryable()
                .GroupBy(x => x.Status)
                .Select(x => new ProductStatResponseModel() { Status = x.Key.ToString(), Count = x.Count() })
                .ToList();

            return Task.FromResult(stat);
        }

        public async Task SellProduct(SellProductModel model)
        {
            var product = productRepository.Get(p => p.Id == model.ProductId).FirstOrDefault();

            if (product == null)
                throw new Exception("Product not found");

            product.Sell();

            await productRepository.UpdateAsync(product);
        }
    }
}
