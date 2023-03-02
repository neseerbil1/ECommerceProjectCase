using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerBusiness.Abstract
{
    public interface IGenericService<T>
    {
        List<T> GetList();
        void TAdd(T t);
        void TDelete(T t);
        void TUpdate(T t);
        T TGetByID(int id);
    }
}
