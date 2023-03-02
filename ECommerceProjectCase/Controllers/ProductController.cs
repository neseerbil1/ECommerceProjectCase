using LayerBusiness.Abstract;
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
        private readonly IProductService _productService;
        private readonly IDiscountService _discountService;
        private readonly ICategoryDiscountService _categoryDiscountService;

        public ProductController(IProductService productService, IDiscountService discountService, ICategoryDiscountService categoryDiscountService)
        {
            _productService = productService;
            _discountService = discountService;
            _categoryDiscountService = categoryDiscountService;
        }

        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = _productService.GetList();
            return View(products);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.DiscountList = _discountService.GetList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.TAdd(product);
                return RedirectToAction("Index");
            }
            ViewBag.DiscountList = _discountService.GetList();
            return View(product);
        }
        public ActionResult Edit(int id)
        {
            Product product = _productService.TGetByID(id);
            ViewBag.DiscountList = _discountService.GetList();
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.TUpdate(product);
                return RedirectToAction("Index");
            }
            ViewBag.DiscountList = _discountService.GetList();
            return View(product);
        }
        public ActionResult Delete(int id)
        {
            Product product = _productService.TGetByID(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = _productService.TGetByID(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            _productService.TDelete(product);
            return RedirectToAction("Index");
        }
    }
}