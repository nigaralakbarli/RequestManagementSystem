using Microsoft.EntityFrameworkCore;
using RequestManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RequestManagementSystem.Data.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<RequestStatus> RequestStatuses { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestType> RequestTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
 
            modelBuilder.Entity<Request>()
                .HasOne(r => r.CreateUser)
                .WithMany(u => u.CreatedRequests)
                .HasForeignKey(r => r.CreateUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Request>()
                .HasOne(r => r.ExecutorUser)
                .WithMany(u => u.ExecutedRequests)
                .HasForeignKey(r => r.ExecutorUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
