using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.Share
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ProductModel : BaseModel
    {
        public decimal Price { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public decimal? RRP { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ICollection<ProductLinkModel> ProductLinks { get; set; }
        //
        public bool IsShowDetail { get; set; }
    }
    public class ProductCategoryModel : BaseModel
    {
    }
    public class ProductLinkModel : BaseModel
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
