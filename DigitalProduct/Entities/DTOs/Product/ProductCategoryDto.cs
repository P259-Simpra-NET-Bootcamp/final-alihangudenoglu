using Entities.Concrete;

namespace Entities.DTOs
{
    public class ProductCategoryDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int MaxPuan { get; set; }
        public int PuanPercent { get; set; }
        public bool Guarantee { get; set; }
        public bool Status { get; set; }
        public List<Items>? CategoryProducts { get; set; }
    }
    //public class Items
    //{
       
    //    public int CategoryId { get; set; }
    //}
        
    
}
