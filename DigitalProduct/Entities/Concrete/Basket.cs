using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Basket:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? DiscountId { get; set; }
        public decimal? TotalPrice { get; set; }

        public List<BasketItem> BasketItems { get; set; }
        
    }
}
