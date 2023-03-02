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
    public class DiscountManager : IDiscountService
    {
        IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }
        public bool IsDiscountValid(int discountId)
        {
            var discount = _discountDal.GetByID(discountId);
            return discount != null && discount.StartDate <= DateTime.Today && discount.EndDate >= DateTime.Today;
        }

        public double CalculateDiscountedPrice(double price, int discountId)
        {
            if (IsDiscountValid(discountId))
            {
                var discount = _discountDal.GetByID(discountId);
                var discountRate = discount.DiscountRate / 100.0;
                return price - (price * discountRate);
            }
            else
            {
                return price;
            }
        }
        public List<Discount> GetList()
        {
           return _discountDal.List();  
        }

        public void TAdd(Discount t)
        {
            _discountDal.Insert(t);

        }

        public void TDelete(Discount t)
        {
            _discountDal.Delete(t);
        }

        public void TUpdate(Discount t)
        {
           _discountDal.Update(t);
        }

        public Discount TGetByID(int id)
        {
            return _discountDal.GetByID(id);
        }
    }
}
