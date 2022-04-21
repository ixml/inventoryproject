using System;
using System.ComponentModel.DataAnnotations;
using Inventory.Domain.Enums;

namespace Inventory.Domain.Models
{
    public class ChangeProductStatusModel
    {
        [Required]
        public float ProductId { get; set; }

        [Required]
        public ProductStatus Status { get; set; }
    }
}
