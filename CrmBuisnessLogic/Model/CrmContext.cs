using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBuisnessLogic.Model
{

    public class CrmContext:DbContext
    {
        public CrmContext() : base("CrmConnection") { }
        public DbSet<Check> Checks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sell>Sells { get; set; }
        public DbSet<Seller> Sellers { get; set; }
    }
}
