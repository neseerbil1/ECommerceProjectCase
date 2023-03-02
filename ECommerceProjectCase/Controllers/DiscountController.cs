using LayerBusiness.Abstract;
using LayerDataAccess.Abstract;
using LayerEntity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceProjectCase.Controllers
{
    public class DiscountController : Controller
    {
        // GET: Discount
        private readonly IProductService _productService;
        private readonly IDiscountService _discountService;
        private readonly ICategoryDiscountService _categoryDiscountService;
        private readonly ICampaignService _campaignService;

        public DiscountController(IProductService productService, IDiscountService discountService, ICategoryDiscountService categoryDiscountService, ICampaignService campaignService)
        {
            _productService = productService;
            _discountService = discountService;
            _categoryDiscountService = categoryDiscountService;
            _campaignService = campaignService;
        }

        // GET: Discount
        public ActionResult Index()
        {
            var discounts = _discountService.GetList();
            return View(discounts);
        }

        // GET: Discount/Create
        public ActionResult Create()
        {
            ViewBag.CategoryDiscounts = new SelectList(_categoryDiscountService.GetList(), "Id", "Category");
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
                _campaignService.TAdd(campaign);

                discount.Id = campaign.ID;
                _discountService.TAdd(discount);

                foreach (var categoryDiscountId in categoryDiscountIds)
                {
                    var categoryDiscount = _categoryDiscountService.TGetByID(categoryDiscountId);

                    var productIds = _productService.GetList(p => p.Category == categoryDiscount.Category).Select(p => p.Id).ToList();
                    foreach (var productId in productIds)
                    {
                        var product = _productService.TGetByID(productId);
                        product.CategoryDiscounts.Add(categoryDiscount);
                        _productService.TUpdate(product);
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult AddCampaign()
        {
            ViewBag.Discounts = _discountService.GetList();
            return View();
        }

        [HttpPost]
        public ActionResult AddCampaign(Campaign campaign)
        {
            if (ModelState.IsValid)
            {
                campaign.StartDate = DateTime.Now;
                _campaignService.TAdd(campaign);
                return RedirectToAction("Index");
            }

            ViewBag.Discounts = _discountService.GetList();
            return View(campaign);
        }
       
    }
}