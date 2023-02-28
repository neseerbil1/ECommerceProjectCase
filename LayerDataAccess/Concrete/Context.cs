using LayerEntity.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerDataAccess.Concrete
{
    public class Context:DbContext
    {
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<CategoryDiscount> CategoryDiscounts { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
