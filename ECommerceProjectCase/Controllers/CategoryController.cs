using LayerBusiness.Abstract;
using LayerBusiness.Concrete;
using LayerDataAccess.EntityFramework;
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
    }
}
    
