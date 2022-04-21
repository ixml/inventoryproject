using System;
namespace Inventory.Domain.Entities
{
    public class EntityBase
    {

        public DateTime CreatedOn { get; protected set; }
        public DateTime? UpdatedOn { get; set; }

    }
}
