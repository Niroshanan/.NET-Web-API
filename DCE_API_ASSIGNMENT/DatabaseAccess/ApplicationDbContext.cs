using DCE_API_ASSIGNMENT.Models;
using Microsoft.EntityFrameworkCore;

namespace DCE_API_ASSIGNMENT.DatabaseAccess
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<ActiveOrdersByCustomer> Order { get; set; }
        public DbSet<Product> Product { get; set; }

        public DbSet<ActiverOrder> activerOrder { get; set; }
        

    }
}
