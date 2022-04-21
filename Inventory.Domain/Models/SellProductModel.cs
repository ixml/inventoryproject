using System;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Domain.Models
{
    public class SellProductModel
    {
        [Required]
        public float ProductId { get; set; }
    }
}
