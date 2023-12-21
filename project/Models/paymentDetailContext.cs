using Microsoft.EntityFrameworkCore;

namespace project.Models
{
    public class paymentDetailContext : DbContext

    {
        public paymentDetailContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<projectPayment> projectPayment { get; set; }
    }
}
