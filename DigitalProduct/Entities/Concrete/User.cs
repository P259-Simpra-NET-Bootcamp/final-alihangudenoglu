using Entities.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User:IdentityUser<int>,IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Basket? Basket { get; set; }
        public List<Order>? Orders { get; set; }
        public List<Discount>? Discounts { get; set; }
        public Wallet? Wallet { get; set; }
    }
}
