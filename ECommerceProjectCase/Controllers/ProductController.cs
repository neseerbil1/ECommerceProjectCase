using LayerBusiness.Abstract;
using LayerBusiness.Concrete;
using LayerDataAccess.EntityFramework;
using LayerEntity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceProjectCase.Controllers
{
    public class ProductController : Controller
    {
        DiscountManager dm = new DiscountManager(new EfDiscountDal());
        ProductManager pm = new ProductManager(new EfProductDal(), new EfDiscountDal(), new EfCampaignDal());
        CategoryDiscountManager cdm = new CategoryDiscountManager(new EfCategoryDiscountDal());

       

        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = pm.GetList();
            return View(products);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.DiscountList = dm.GetList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                pm.TAdd(product);
                return RedirectToAction("Index");
            }
            ViewBag.DiscountList = dm.GetList();
            return View(product);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Product product = pm.TGetByID(id.Value);
            ViewBag.DiscountList = dm.GetList();
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                pm.TUpdate(product);
                return RedirectToAction("Index");
            }
            ViewBag.DiscountList = dm.GetList();
            return View(product);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Product product = pm.TGetByID(id.Value);
           
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Product product = pm.TGetByID(id.Value);
           
            pm.TDelete(product);
            return RedirectToAction("Index");
        }
    }
}