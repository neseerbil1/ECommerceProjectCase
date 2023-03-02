using LayerEntity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerBusiness.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> GetByCategory(string category);
        List<Product> GetList(Func<Product, bool> filter = null);

    }
}