using System;
using System.Collections.Generic;

namespace Inventory.Domain.Entities.Category
{
    public partial class Category : EntityBase
    {
        public int Id { get; protected set; }

        public string Name { get; protected set; }


        private ICollection<Product> _products;
        public ICollection<Product> Products
        {
            get { return _products; }
        }




    }
}
