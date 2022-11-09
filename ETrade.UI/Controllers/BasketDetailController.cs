using ETrade.Entity.Concretes;
using ETrade.UI.Models;
using ETrade.Uw;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

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
            _basketDetailModel.basketDetailDTO = _uow._basketDetailRep.basketDetailDTOs(id);
            return View(_basketDetailModel);
        }
        [HttpPost]
        public IActionResult Add(BasketDetailModel m,int id)
        {
            Products products = _uow._productsRep.FindWithVAT(m.ProductId);
            _basketDetail.Amount = m.Amount;
            _basketDetail.ProductId = m.ProductId;
            _basketDetail.Id= id;
            _basketDetail.UnitId = products.UnitId;
            _basketDetail.Ratio = products.Vat.Ratio;
            _basketDetail.UnitPrice = products.UnitPrice;
            _uow._basketDetailRep.Add(_basketDetail);
            _uow.Commit();
          //  _basketDetailModel.ProductsDTO = _uow._productsRep.GetProductsSelect();
          //  _basketDetailModel.basketDetailDTO = _uow._basketDetailRep.basketDetailDTOs(id);
            return RedirectToAction("Add", new {id});
        }
        public IActionResult Delete(int Id,int productId)
        {
            _uow._basketDetailRep.Delete(Id, productId);
            _uow.Commit();
            return RedirectToAction("Add", new { Id });
        }
        public IActionResult Update(int Id,int productId)
        {
            var SelectedBDetail = _uow._basketDetailRep.Find(Id, productId);
            return View(SelectedBDetail);
        }
        [HttpPost]
        public IActionResult Update(int Amount, int Id, int productId)
        {
            var SelectedBDetail = _uow._basketDetailRep.Find(Id, productId);
            SelectedBDetail.Amount = Amount;
            _uow._basketDetailRep.Update(SelectedBDetail);
            _uow.Commit();
            return RedirectToAction("Add", new { Id });
        }

    }
}
