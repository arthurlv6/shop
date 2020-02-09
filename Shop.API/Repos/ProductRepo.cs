using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.API.DB;
using Shop.Share;
using System.Collections.Generic;
using System.Linq;

namespace Shop.API.Repos
{
    public class ProductRepo:BaseRepo
    {
        public ProductRepo(APIDBContext _dBContext, IMapper _mapper) : base(_dBContext, _mapper)
        {
        }
        public override IEnumerable<M> GetAll<T, M>(int page = 0, int size = 20, string keyword = "")
        {
            return dBContext.Set<Product>().Include(d => d.ProductLinks).Select(d => d.ToModel<M>(mapper));
        }
    }
}
