using LayerEntity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerBusiness.Abstract
{
    public interface IDiscountService : IGenericService<Discount>
    {
        bool IsDiscountValid(int discountId);
        double CalculateDiscountedPrice(double price, int discountId);


    }
}
