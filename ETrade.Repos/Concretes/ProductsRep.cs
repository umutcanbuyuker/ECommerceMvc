using ETrade.Core;
using ETrade.Dal;
using ETrade.Dto;
using ETrade.Entity.Concretes;
using ETrade.Repos.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Repos.Concretes
{
    public class ProductsRep<T> : BaseRepository<Products>, IProductsRep where T : class
    {
        public ProductsRep(TradeContext db) : base(db)
        {
        }

        public List<ProductDTO> GetProductsSelect()
        {
           return Set().Select(x=> new ProductDTO {Id = x.Id, ProductName=x.ProductName}).ToList();
        }
    }
}
