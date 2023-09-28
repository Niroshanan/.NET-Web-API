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
        public DbSet<ActiveOrders> Order { get; set; }
    }
}
