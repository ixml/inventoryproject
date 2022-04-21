using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Domain.Models;
using Inventory.Domain.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {

        private IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        [HttpGet("stat")]
        public async Task<IActionResult> Stat()
        {
            var result = await productService.GetProductStat();
            return Ok(result);
        }

        [HttpPost("sell")]
        public async Task<IActionResult> Sell([FromBody] SellProductModel model)
        {
            await productService.SellProduct(model);
            return Ok();
        }

        [HttpPost("change-status")]
        public async Task<IActionResult> ChangeStatus([FromBody] ChangeProductStatusModel model)
        {
            await productService.ChangeProductStatus(model);
            return Ok();
        }
    }
}
