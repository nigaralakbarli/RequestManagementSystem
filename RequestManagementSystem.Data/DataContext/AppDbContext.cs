using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public DbSet<Models.Action> Actions { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }


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

            modelBuilder.Entity<RequestStatus>().HasData(
                new RequestStatus { Id = 1, Name = "Open"} ,
                new RequestStatus { Id = 2, Name = "In Execution" },
                new RequestStatus { Id = 3, Name = "Rejected" },
                new RequestStatus { Id = 4, Name = "Waiting" },
                new RequestStatus { Id = 5, Name = "Approved" },
                new RequestStatus { Id = 6, Name = "Close" } );

            modelBuilder.Entity<Priority>().HasData(
                new Priority { Id = 1, Level = "Low" },
                new Priority { Id = 2, Level = "Medium" },
                new Priority { Id = 3, Level = "High" });

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Information Technologies" },
                new Department { Id = 2, Name = "Human Resources" },
                new Department { Id = 3, Name = "Data Analysis" });

            modelBuilder.Entity<RequestType>().HasData(
                new RequestType { Id = 1, Name = "APP Change" },
                new RequestType { Id = 2, Name = "APP Issue" },
                new RequestType { Id = 3, Name = "APP New Requirement" },
                new RequestType { Id = 4, Name = "Change the Report" },
                new RequestType { Id = 5, Name = "Crate Custom Report" },
                new RequestType { Id = 6, Name = "Create New Rrport" },
                new RequestType { Id = 7, Name = "Incident" },
                new RequestType { Id = 8, Name = "Master Data Change" },
                new RequestType { Id = 9, Name = "Service Request" });

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "3E - AGIS"},
                new Category { Id = 2, Name = "3E - dəstək" },
                new Category { Id = 3, Name = "3rd Party" },
                new Category { Id = 4, Name = "abc web site" },
                new Category { Id = 5, Name = "AGIS - Debitor" },
                new Category { Id = 6, Name = "AD SOCAR Romania" },
                new Category { Id = 7, Name = "Agis - Proqram təminatı" },
                new Category { Id = 8, Name = "ailem.socar.az" },
                new Category { Id = 9, Name = "ant.socar.az" },
                new Category { Id = 10, Name = "ASAN web service" },
                new Category { Id = 11, Name = "Azeriqaz sms" },
                new Category { Id = 12, Name = "azkob.az" },
                new Category { Id = 13, Name = "Call Center" },
                new Category { Id = 14, Name = "CIC web site" },
                new Category { Id = 15, Name = "CVS web site" },
                new Category { Id = 16, Name = "AD SOCAR Romania" },
                new Category { Id = 17, Name = "ailem.socar.az" }
                );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Nigar", Password = "nigar123", InternalNumber = "123456", ContactNumber = "+995 551234567", AllowNotification = true, Role = "Admin", Image = "nigar's image", DepartmentId = 1, Position = "meslehetci" }
                ) ;
        }
    }
}
