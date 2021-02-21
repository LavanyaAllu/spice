using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spice.DomainModel;

namespace Spice.DataLayer
{
    public class SpiceDbContext:DbContext
    {
        public SpiceDbContext():base("conn")
        {

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<MenuItems> MenuItems { get; set; }
        //public DbSet<Coupon> Coupon { get; set; }

    }
}
