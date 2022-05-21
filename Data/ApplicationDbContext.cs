using Patient_Management_System.Web.Configuration.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Patient_Management_System.Web.Models;
using Patient_Management_System.Web.Data;

namespace Patient_Management_System.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<Employee>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new UserSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedConfiguration());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                 .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.Now;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Patient_Management_System.Web.Data.Doctor> Doctor { get; set; }

    }
}