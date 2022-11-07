using ETrade.Entity.Concretes;
using ETrade.UI.Models;
using ETrade.Uw;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.UI.Controllers
{
    public class BasketDetailController : Controller
    {
        BasketDetail _basketDetail;
        IUow _uow;
        BasketDetailModel _basketDetailModel;
        public BasketDetailController(BasketDetail basketDetail, IUow uow,BasketDetailModel basketDetailModel)
        {
          _basketDetail = basketDetail;
          _uow = uow;
          _basketDetailModel = basketDetailModel;
        }
        public IActionResult Add(int id)
        {
            _basketDetailModel.ProductsDTO = _uow._productsRep.GetProductsSelect();
            return View(_basketDetailModel);
        }
    }
}
