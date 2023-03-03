using LayerBusiness.Abstract;
using LayerBusiness.Concrete;
using LayerDataAccess.Abstract;
using LayerDataAccess.EntityFramework;
using LayerEntity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease;

namespace ECommerceProjectCase.Controllers
{
    public class DiscountController : Controller
    {
        DiscountManager dm = new DiscountManager(new EfDiscountDal());
        ProductManager pm = new ProductManager(new EfProductDal(), new EfDiscountDal(), new EfCampaignDal());
        CampaignManager cm = new CampaignManager(new EfCampaignDal(), new EfProductDal());
        CategoryDiscountManager cdm = new CategoryDiscountManager(new EfCategoryDiscountDal());

        // GET: Discount
        public ActionResult Index()
        {
            var discounts = dm.GetList();
            return View(discounts);
        }

        // GET: Discount/Create
        public ActionResult Create()
        {
            ViewBag.CategoryDiscounts = new SelectList(cdm.GetList(), "Id", "Category");
            return View();
        }

        // POST: Discount/Create
        [HttpPost]
        public ActionResult Create(Discount discount, List<int> categoryDiscountIds)
        {
            try
            {
                var campaign = new Campaign
                {
                    Name = discount.Name,
                    StartDate = discount.StartDate,
                    EndDate = discount.EndDate
                };
                cm.TAdd(campaign);

                discount.Id = campaign.ID;
               dm.TAdd(discount);

                foreach (var categoryDiscountId in categoryDiscountIds)
                {
                    var categoryDiscount = cdm.TGetByID(categoryDiscountId);

                    var productIds = pm.GetListByFunc(p => p.Category == categoryDiscount.Category).Select(p => p.Id).ToList();
                    foreach (var productId in productIds)
                    {
                        var product = pm.TGetByID(productId);
                        product.CategoryDiscounts.Add(categoryDiscount);
                        pm.TUpdate(product);
                    }
                }
                ViewBag.CategoryDiscounts = new SelectList(cdm.GetList(), "Id", "Category");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult AddCampaign()
        {
            ViewBag.Discounts = dm.GetList();
            return View();
        }

        [HttpPost]
        public ActionResult AddCampaign(Campaign campaign)
        {
            if (ModelState.IsValid)
            {
                campaign.StartDate = DateTime.Now;
                cm.TAdd(campaign);
                return RedirectToAction("Index");
            }

            ViewBag.Discounts = dm.GetList();
            return View(campaign);
        }

    }
}
