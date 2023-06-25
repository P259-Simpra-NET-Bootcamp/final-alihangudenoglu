using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }        
        public int Stock { get; set; }
        public int MaxPuan { get; set; }
        public int PuanPercent { get; set; }
        public bool Guarantee { get; set; }
        public bool Status { get; set; }

        public virtual List<CategoryProduct>? CategoryProducts { get; set; }
        public virtual OrderItem? OrderItem { get; set; }
        public virtual BasketItem? BasketItem { get; set; }
    }

}
