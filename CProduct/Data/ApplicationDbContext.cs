using CProduct.Models;

using Microsoft.EntityFrameworkCore;

namespace CProduct.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {

        }
        public DbSet<Product> products { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
