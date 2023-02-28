using LayerBusiness.Abstract;
using LayerDataAccess.Abstract;
using LayerEntity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerBusiness.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IDiscountDal _discountDal;
        private readonly ICampaignDal _campaignDal;

        public ProductManager(IProductDal productDal, IDiscountDal discountDal, ICampaignDal campaignDal)
        {
            _productDal = productDal;
            _discountDal = discountDal;
            _campaignDal = campaignDal;
        }

        public List<Product> GetList()
        {
            var products = _productDal.List();
            foreach (var product in products)
            {
                product.Price = ApplyDiscounts(product);
            }
            return products;

        }
        private double ApplyDiscounts(Product product)
        {
            double price = product.Price;
            var categoryDiscounts = product.CategoryDiscounts;
            foreach (var categoryDiscount in categoryDiscounts)
            {
                var discount = _discountDal.GetByID(categoryDiscount.DiscountId);
                if (discount.StartDate <= DateTime.Today && discount.EndDate >= DateTime.Today)
                {
                    price -= price * discount.DiscountRate / 100;
                }
            }
            var campaigns = _campaignDal.List(c => c.StartDate <= DateTime.Today && c.EndDate >= DateTime.Today);
            foreach (var campaign in campaigns)
            {
                var campaignProducts = _productDal.List(p => p.Category == product.Category);
                var totalAmount = campaignProducts.Sum(p => p.Price);
               
            }
            return price;
        }

        public void TAdd(Product t)
        {
            _productDal.Insert(t);
        }

        public void TDelete(Product t)
        {
            _productDal.Delete(t);
        }

        public void TUpdate(Product t)
        {
            _productDal.Update(t);
        }
    }
}
