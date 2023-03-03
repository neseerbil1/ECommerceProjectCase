using LayerDataAccess.Abstract;
using LayerDataAccess.Concrete;
using LayerEntity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerDataAccess.EntityFramework
{
    public class EfCategoryDiscountDal : Repository<CategoryDiscount>, ICategoryDiscountDal
    {
    }
}
