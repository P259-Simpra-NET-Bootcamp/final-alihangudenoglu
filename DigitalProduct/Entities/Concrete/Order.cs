using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? DiscountId { get; set; }
        public decimal BasketTotal { get; set; }
        public decimal? UsedPuan { get; set; }
        public decimal GainedPuan { get; set; }

        public User User { get; set; }
        public Discount Discount { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
