using ETrade.Core;
using ETrade.Dto;
using ETrade.Entity.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Repos.Abstracts
{
    public interface IBasketDetailRep : IBaseRepository<BasketDetail>
    {
        List<BasketDetailDTO> basketDetailDTOs(int MasterId); //login olmuş user'a ait sepeti çekeceğiz. Yoksa bütün sepetleri çeker. 
        // yukarıdaki masterId basketmastercontroller 30'daki Id den basketmaster'a ait Id çeker.
        
    }
}
