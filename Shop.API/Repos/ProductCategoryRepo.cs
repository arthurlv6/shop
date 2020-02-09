using AutoMapper;
using Shop.API.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Repos
{
    public class ProductCategoryRepo:BaseRepo
    {
        public ProductCategoryRepo(APIDBContext _dBContext, IMapper _mapper) : base(_dBContext, _mapper)
        {
        }
    }
}
