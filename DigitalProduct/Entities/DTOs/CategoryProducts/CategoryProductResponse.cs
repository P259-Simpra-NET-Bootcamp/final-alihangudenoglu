using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.CategoryProducts
{
    public class CategoryProductResponse
    {
        
        public int CategoryId { get; set; }
        public Product Product { get; set; }
    }
}
