using LayerEntity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerBusiness.Abstract
{
    public interface ICategoryDiscountService:IGenericService<CategoryDiscount>
    {
        List<CategoryDiscount> GetByCategory(string category);
        List<Discount> GetActiveDiscountsForCategory(string category);
        double GetDiscountedPrice(Product product);
    }
}
