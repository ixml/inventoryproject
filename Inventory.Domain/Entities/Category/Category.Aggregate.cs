using System;
using System.Collections.Generic;
using Inventory.Domain.Enums;

namespace Inventory.Domain.Entities.Category
{
	public partial class Category
	{
		public Category()
        {
			this._products = new HashSet<Product>();
        }


		public Category(string name)
		{
			this.Name = name;
		}



		public Product AddProduct(string name, string barcode, string description, double weight, ProductStatus productStatus)
		{
			var product = new Product(name,barcode,description,weight,productStatus);

			this._products.Add(product);
			return product;
		}

	}
}
