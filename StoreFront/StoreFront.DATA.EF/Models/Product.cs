using System;
using System.Collections.Generic;

namespace StoreFront.DATA.EF.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public int ProductStatusId { get; set; }
        public string? ProductDescription { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitCost { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReorderTrigger { get; set; }
        public decimal? UnitWeightLbs { get; set; }
        public decimal? UnitSizeFlOunce { get; set; }
        public string? ProductImage { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ProductStatus ProductStatus { get; set; } = null!;
        public virtual Supplier Supplier { get; set; } = null!;
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
