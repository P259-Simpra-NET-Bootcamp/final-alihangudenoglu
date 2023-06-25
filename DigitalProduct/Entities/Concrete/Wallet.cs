﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Wallet : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Balance { get; set; }

        public User User { get; set; }
    }
}
