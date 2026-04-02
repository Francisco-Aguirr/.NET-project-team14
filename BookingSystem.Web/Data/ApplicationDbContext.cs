using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BusinessCategory> BusinessCategories => Set<BusinessCategory>();
        public DbSet<EntrepreneurRequest> EntrepreneurRequests => Set<EntrepreneurRequest>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<WorkSchedule> WorkSchedules => Set<WorkSchedule>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.WorkSchedules)
                .WithOne(ws => ws.Employee)
                .HasForeignKey(ws => ws.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
