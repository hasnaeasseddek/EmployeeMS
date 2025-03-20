﻿using EmployeeMS.Domain.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<JobOffer> jobOffers { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> department { get; set; }
        public DbSet<Position> positions { get; set; }
        public DbSet<Contract> contracts { get; set; }
        public DbSet<Attendance> attendances { get; set; }
        public DbSet<LeaveRequest> leaveRequests { get; set; }
        public DbSet<Training> trainings { get; set; }
        public DbSet<EmployeeTraining> employeeTrainings { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                if(entry.State == EntityState.Added)
                    entry.Entity.DateCreated = DateTime.Now;
                entry.Entity.LastModifiedDate = DateTime.Now;
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
