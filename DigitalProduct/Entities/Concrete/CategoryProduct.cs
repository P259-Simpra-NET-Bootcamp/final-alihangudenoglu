﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CategoryProduct : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Category? Category { get; set; }
    }
}
