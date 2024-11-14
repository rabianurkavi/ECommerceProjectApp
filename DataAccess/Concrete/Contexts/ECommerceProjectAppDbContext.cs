using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Contexts
{
    public class ECommerceProjectAppDbContext:DbContext
    {
        public ECommerceProjectAppDbContext(DbContextOptions<ECommerceProjectAppDbContext> options):base(options)
        {
            
        }
        public ECommerceProjectAppDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=RABIA\\SQLEXPRESS;Database=ECommerceProjectDB;Trusted_Connection=True;");
        }
    }
}
