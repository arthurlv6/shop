using Microsoft.AspNetCore.Mvc;
using Shop.API.Repos;
using Shop.Share;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepo repo;
        public ProductController(ProductRepo _repo)
        {
            repo = _repo;
        }
        // GET: api/Product
        [HttpGet]
        public IActionResult Get(int page=0,int size=20,string keyword="")
        {
            return Ok(repo.GetAll<Product, ProductModel>(page,size,keyword));
        }
    }
}
