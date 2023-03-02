using LayerBusiness.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceProjectCase.Controllers
{
    public class CategoryController : Controller
    {
        private IProductService _productService;
        private ICategoryDiscountService _categoryDiscountService;
        private IDiscountService _discountService;

        public CategoryController(IProductService productService, ICategoryDiscountService categoryDiscountService, IDiscountService discountService)
        {
            _productService = productService;
            _categoryDiscountService = categoryDiscountService;
            _discountService = discountService;
        }

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(string category)
        {
            var products = _productService.GetByCategory(category);

            foreach (var product in products)
            {
                var categoryDiscounts = _categoryDiscountService.GetByCategory(product.Category);

                foreach (var categoryDiscount in categoryDiscounts)
                {
                    var discount = _discountService.TGetByID(categoryDiscount.DiscountId);

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
    
