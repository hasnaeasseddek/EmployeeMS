using EmployeeMS.Domain.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EmployeeMS.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<JobOffer> jobOffers { get; set; }
        public DbSet<InternshipApplication> InternshipApplications { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> department { get; set; }
        public DbSet<Position> positions { get; set; }
        public DbSet<Contract> contracts { get; set; }
        public DbSet<Attendance> attendances { get; set; }
        public DbSet<LeaveRequest> leaveRequests { get; set; }
        public DbSet<Training> trainings { get; set; }
        public DbSet<EmployeeTraining> employeeTrainings { get; set; }
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Permission> Permissions => Set<Permission>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany()
                .UsingEntity(j => j.ToTable("UserRoles"));

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Permissions)
                .WithMany()
                .UsingEntity(j => j.ToTable("RolePermissions"));
        }

        
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                if (entry.State == EntityState.Added)
                    entry.Entity.DateCreated = DateTime.Now;
                entry.Entity.LastModifiedDate = DateTime.Now;
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
