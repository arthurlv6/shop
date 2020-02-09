using Microsoft.AspNetCore.Mvc;
using Shop.API.Repos;
using Shop.Share;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductLinkController : ControllerBase
    {
        private readonly ProductLinkRepo repo;
        public ProductLinkController(ProductLinkRepo _repo)
        {
            repo = _repo;
        }
        // GET: api/Product
        [HttpGet]
        public IActionResult Get(int page=0,int size=20,string keyword="")
        {
            return Ok(repo.GetAll<Product, ProductModel>(page,size,keyword));
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] ProductLinkModel productLinkModel)
        {
            if (productLinkModel == null)
                return BadRequest();

            if (productLinkModel.Address == string.Empty || productLinkModel.Type == string.Empty)
            {
                ModelState.AddModelError("link address and type", "The address and type shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var createdLink = repo.AddProductLink(productLinkModel);

            return Created("productLink", createdLink);
        }
    }
}
