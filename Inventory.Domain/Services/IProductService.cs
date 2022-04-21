using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inventory.Domain.Models;

namespace Inventory.Domain.Services
{
    public interface IProductService
    {
        Task SellProduct(SellProductModel model);

        Task ChangeProductStatus(ChangeProductStatusModel model);
        Task<List<ProductStatResponseModel>> GetProductStat();
    }
}
