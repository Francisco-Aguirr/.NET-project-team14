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
        public DbSet<Business> Businesses => Set<Business>();
        public DbSet<BusinessService> BusinessServices => Set<BusinessService>();
        public DbSet<EntrepreneurRequest> EntrepreneurRequests => Set<EntrepreneurRequest>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<WorkSchedule> WorkSchedules => Set<WorkSchedule>();
        public DbSet<Appointment> Appointments => Set<Appointment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.WorkSchedules)
                .WithOne(ws => ws.Employee)
                .HasForeignKey(ws => ws.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Business)
                .WithMany(b => b.Employees)
                .HasForeignKey(e => e.BusinessId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.BusinessId);

            modelBuilder.Entity<Business>()
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Business>()
                .HasIndex(b => b.UserId)
                .IsUnique();

            modelBuilder.Entity<BusinessService>()
                .HasOne(s => s.Business)
                .WithMany(b => b.Services)
                .HasForeignKey(s => s.BusinessId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BusinessService>()
                .HasIndex(s => s.BusinessId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.BusinessService)
                .WithMany()
                .HasForeignKey(a => a.BusinessServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Employee)
                .WithMany()
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Appointment>()
                .HasIndex(a => new { a.EmployeeId, a.AppointmentStart, a.AppointmentEnd });

            modelBuilder.Entity<Appointment>()
                .HasIndex(a => a.BusinessServiceId);
        }
    }
}