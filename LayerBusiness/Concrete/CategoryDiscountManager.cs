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
    public class CategoryDiscountManager : ICategoryDiscountService
    {
        ICategoryDiscountDal _categoryDiscountDal;

        public CategoryDiscountManager(ICategoryDiscountDal categoryDiscountDal)
        {
            _categoryDiscountDal = categoryDiscountDal;
        }

        public List<CategoryDiscount> GetList()
        {
            return _categoryDiscountDal.List();
        }

        public void TAdd(CategoryDiscount t)
        {
            _categoryDiscountDal.Insert(t);
        }

        public void TDelete(CategoryDiscount t)
        {
            _categoryDiscountDal.Delete(t);
        }

        public void TUpdate(CategoryDiscount t)
        {
            _categoryDiscountDal.Update(t);
        }
        public List<Discount> GetActiveDiscountsForCategory(string category)
        {
            var now = DateTime.Now;

            var activeCategoryDiscounts = _categoryDiscountDal
                .List(cd => cd.Category == category &&
                            cd.Discount.StartDate <= now &&
                            cd.Discount.EndDate >= now);

            var activeDiscounts = activeCategoryDiscounts
                .Select(cd => cd.Discount)
                .ToList();

            return activeDiscounts;
        }

        // Method to get the discounted price for a given product
        public double GetDiscountedPrice(Product product)
        {
            var activeDiscounts = GetActiveDiscountsForCategory(product.Category);

            var maxDiscountRate = activeDiscounts.Any() ? activeDiscounts.Max(d => d.DiscountRate) : 0;

            var discountedPrice = product.Price - (product.Price * maxDiscountRate / 100);

            return discountedPrice;
        }

        public CategoryDiscount TGetByID(int id)
        {
            return _categoryDiscountDal.GetByID(id);
        }

        public List<CategoryDiscount> GetByCategory(string category)
        {
            return _categoryDiscountDal.List(x => x.Category == category);
        }
    }
}
