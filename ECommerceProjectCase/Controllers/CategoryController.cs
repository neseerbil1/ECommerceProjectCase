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
    public class CategoryController : Controller
    {
        DiscountManager dm = new DiscountManager(new EfDiscountDal());
        ProductManager pm = new ProductManager(new EfProductDal(), new EfDiscountDal(), new EfCampaignDal());
        CategoryDiscountManager cdm = new CategoryDiscountManager(new EfCategoryDiscountDal());
     
        // GET: Category
        public ActionResult Index()
        {
            var categoryDiscounts = cdm.GetList();
            return View(categoryDiscounts);
        }
        public ActionResult List(string category)
        {
            var products = pm.GetByCategory(category);

            foreach (var product in products)
            {
                var categoryDiscounts = cdm.GetByCategory(product.Category);

                foreach (var categoryDiscount in categoryDiscounts)
                {
                    var discount = dm.TGetByID(categoryDiscount.DiscountId);

                    if (DateTime.Now >= discount.StartDate && DateTime.Now <= discount.EndDate)
                    {
                        product.Price = product.Price * (1 - discount.DiscountRate / 100);
                    }
                }
            }

            return View(products);
        }
        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryDiscount categoryDiscount)
        {
            try
            {
                cdm.TAdd(categoryDiscount);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var categoryDiscount = cdm.TGetByID(id);
            return View(categoryDiscount);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategoryDiscount categoryDiscount)
        {
            try
            {
                cdm.TUpdate(categoryDiscount);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var categoryDiscount = cdm.TGetByID(id);
            return View(categoryDiscount);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CategoryDiscount categoryDiscount)
        {
            try
            {
                cdm.TDelete(categoryDiscount);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
    
