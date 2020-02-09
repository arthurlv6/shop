using AutoMapper;
using Shop.API.DB;
using Shop.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Repos
{
    public class ProductLinkRepo:BaseRepo
    {
        public ProductLinkRepo(APIDBContext _dBContext, IMapper _mapper) : base(_dBContext, _mapper)
        {
        }
        public ProductLinkModel AddProductLink(ProductLinkModel productLinkModel)
        {
            var productLink = mapper.Map<ProductLink>(productLinkModel);
            productLink.Product = dBContext.Products.Find(productLinkModel.ProductId);

            var addedEntity = dBContext.ProductLinks.Add(productLink);
            dBContext.SaveChanges();
            return addedEntity.Entity.ToModel<ProductLinkModel>(mapper);
        }
    }
}
