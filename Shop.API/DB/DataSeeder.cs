using Shop.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.DB
{
    public class DataSeeder
    {
        private readonly APIDBContext ctx;
        public DataSeeder(APIDBContext _ctx)
        {
            ctx = _ctx;
        }
        public void Seed()
        {
            ctx.Database.EnsureCreated();
            if (!ctx.Products.Any())
            {
                var items = new List<Product>();
                for (int i = 0; i < 30; i++)
                {
                    items.Add(new Product 
                    { 
                        Name = "Product "+i, 
                        Price = 100, 
                        Color = "Black", 
                        Size = "Medium" ,
                        ProductLinks= new List<ProductLink>()
                        {
                            new ProductLink() { Name = "link" + i, Address = "https://images.unsplash.com/photo-1545594262-7df7e6050326?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=634&q=80" }
                        }
                    });
                }
                ctx.Products.AddRange(items);
                ctx.SaveChanges();
            }
        }
    }
}
