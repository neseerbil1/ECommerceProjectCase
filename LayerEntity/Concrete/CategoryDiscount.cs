using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerEntity.Concrete
{
    public class CategoryDiscount
    {

        public int Id { get; set; }
        public string Category { get; set; }
        public int DiscountId { get; set; }
        public Discount Discount { get; set; }

    }
}
