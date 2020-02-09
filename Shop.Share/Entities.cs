using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Share
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public T ToModel<T>(IMapper mapper) where T : BaseModel
        {
            return mapper.Map<T>(this);
        }
    }
    public class Product : BaseEntity
    {
        public decimal Price { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public decimal? RRP { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ICollection<ProductLink> ProductLinks { get; set; }
    }
    public class ProductCategory : BaseEntity
    {
    }
    public class ProductLink : BaseEntity
    {
        public string Type { get; set; }
        public string Address { get; set; }
        public DateTime? CreatedDate { get; set; }
        public virtual Product Product { get; set; }
    }
}