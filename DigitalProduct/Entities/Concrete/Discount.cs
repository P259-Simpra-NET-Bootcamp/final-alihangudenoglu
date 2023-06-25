using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Discount : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool Status { get; set; }

        public User User { get; set; }
        public Order Order { get; set; }
    }
}
