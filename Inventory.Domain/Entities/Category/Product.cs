using System;
using Inventory.Domain.Enums;

namespace Inventory.Domain.Entities
{
    public class Product : EntityBase
    {
        public int Id { get; protected set; }

        public string Name { get; protected set; }

        public string Barcode { get; protected set; }

        public string Description { get; protected set; }

        public double Weight { get; protected set; }

        public ProductStatus Status { get; protected set; }

        public Product()
        {

        }

        public Product(string name, string barcode, string description,double weight,ProductStatus productStatus)
        {
            this.Name = name;
            Barcode = barcode;
            Description = description;
            Weight = weight;
            Status = productStatus;
        }

        public void Sell()
        {
            if (this.Status == ProductStatus.Sold)
                throw new Exception("Product has already been sold");

            this.Status = ProductStatus.Sold;

        }

        public void ChangeStatus(ProductStatus productStatus)
        {
            this.Status = productStatus;
        }


        ///products(name, barcode, description, weight, status(sold, inStock, damaged))
    }
}
