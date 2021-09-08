using EPM.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPM.Core.ProductManagement
{
    public class Product : BaseModel<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ProductImage { get; set; }
        public string ProductVideo { get; set; }
    }
}
