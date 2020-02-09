using AutoMapper;
using Shop.API.DB;
using Shop.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Repos
{
    public class BaseRepo
    {
        protected readonly APIDBContext dBContext;
        protected readonly IMapper mapper;
        public BaseRepo(APIDBContext _dBContext, IMapper _mapper)
        {
            dBContext = _dBContext;
            mapper = _mapper;
        }
        public virtual IEnumerable<M> GetAll<T, M>(int page=0,int size=20,string keyword = "") where T : BaseEntity where M : BaseModel
        {
            return dBContext.Set<T>()
                .Where(d=>d.Name.Contains(keyword))
                .OrderBy(d=>d.Id)
                .Skip(size*page)
                .Take(size)
                .Select(d => d.ToModel<M>(mapper));
        }
    }
}
