﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RequestManagementSystem.Data.DataContext;

#nullable disable

namespace RequestManagementSystem.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RequestManagementSystem.Data.Models.Action", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("RequestId")
                        .HasColumnType("integer");

                    b.Property<int>("RequestStatusId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.HasIndex("RequestStatusId");

                    b.ToTable("Action");
                });

            modelBuilder.Entity("RequestManagementSystem.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "3E - AGIS"
                        },
                        new
                        {
                            Id = 2,
                            Name = "3E - dəstək"
                        },
                        new
                        {
                            Id = 3,
                            Name = "3rd Party"
                        },
                        new
                        {
                            Id = 4,
                            Name = "abc web site"
                        },
                        new
                        {
                            Id = 5,
                            Name = "AGIS - Debitor"
                        },
                        new
                        {
                            Id = 6,
                            Name = "AD SOCAR Romania"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Agis - Proqram təminatı"
                        },
                        new
                        {
                            Id = 8,
                            Name = "ailem.socar.az"
                        },
                        new
                        {
                            Id = 9,
                            Name = "ant.socar.az"
                        },
                        new
                        {
                            Id = 10,
                            Name = "ASAN web service"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Azeriqaz sms"
                        },
                        new
                        {
                            Id = 12,
                            Name = "azkob.az"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Call Center"
                        },
                        new
                        {
                            Id = 14,
                            Name = "CIC web site"
                        },
                        new
                        {
                            Id = 15,
                            Name = "CVS web site"
                        },
                        new
                        {
                            Id = 16,
                            Name = "AD SOCAR Romania"
                        },
                        new
                        {
                            Id = 17,
                            Name = "ailem.socar.az"
                        });
                });

            modelBuilder.Entity("RequestManagementSystem.Data.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Information Technologies"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Human Resources"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Data Analysis"
                        });
                });

            modelBuilder.Entity("RequestManagementSystem.Data.Models.Priority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Priorities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Level = "Low"
                        },
                        new
                        {
                            Id = 2,
                            Level = "Medium"
                        },
                        new
                        {
                            Id = 3,
                            Level = "High"
                        });
                });

            modelBuilder.Entity("RequestManagementSystem.Data.Models.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<int>("CreateUserId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ExecutorUserId")
                        .HasColumnType("integer");

                    b.Property<string>("FileUpload")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PriorityId")
                        .HasColumnType("integer");

                    b.Property<int>("RequestStatusId")
                        .HasColumnType("integer");

                    b.Property<int>("RequestTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreateUserId");

                    b.HasIndex("ExecutorUserId");

                    b.HasIndex("PriorityId");

                    b.HasIndex("RequestStatusId");

                    b.HasIndex("RequestTypeId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("RequestManagementSystem.Data.Models.RequestStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RequestStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Open"
                        },
                        new
                        {
                            Id = 2,
                            Name = "In Execution"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Rejected"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Waiting"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Approved"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Close"
                        });
                });

            modelBuilder.Entity("RequestManagementSystem.Data.Models.RequestType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RequestTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "APP Change"
                        },
                        new
                        {
                            Id = 2,
                            Name = "APP Issue"
                        },
                        new
                        {
                            Id = 3,
                            Name = "APP New Requirement"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Change the Report"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Crate Custom Report"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Create New Rrport"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Incident"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Master Data Change"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Service Request"
                        });
                });

            modelBuilder.Entity("RequestManagementSystem.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("AllowNotification")
                        .HasColumnType("boolean");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("InternalNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RequestManagementSystem.Data.Models.Action", b =>
                {
                    b.HasOne("RequestManagementSystem.Data.Models.Request", "Request")
                        .WithMany("Actions")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RequestManagementSystem.Data.Models.RequestStatus", "RequestStatus")
                        .WithMany("Actions")
                        .HasForeignKey("RequestStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Request");

                    b.Navigation("RequestStatus");
                });

            modelBuilder.Entity("RequestManagementSystem.Data.Models.Request", b =>
                {
                    b.HasOne("RequestManagementSystem.Data.Models.Category", "Category")
                        .WithMany("Requests")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RequestManagementSystem.Data.Models.User", "CreateUser")
                        .WithMany("CreatedRequests")
                        .HasForeignKey("CreateUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RequestManagementSystem.Data.Models.User", "ExecutorUser")
                        .WithMany("ExecutedRequests")
                        .HasForeignKey("ExecutorUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RequestManagementSystem.Data.Models.Priority", "Priority")
                        .WithMany("Requests")
                        .HasForeignKey("PriorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RequestManagementSystem.Data.Models.RequestStatus", "RequestStatus")
                        .WithMany("Requests")
                        .HasForeignKey("RequestStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RequestManagementSystem.Data.Models.RequestType", "RequestType")
                        .WithMany("Requests")
                        .HasForeignKey("RequestTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("CreateUser");

                    b.Navigation("ExecutorUser");

                    b.Navigation("Priority");

                    b.Navigation("RequestStatus");

                    b.Navigation("RequestType");
                });

            modelBuilder.Entity("RequestManagementSystem.Data.Models.User", b =>
                {
                    b.HasOne("RequestManagementSystem.Data.Models.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("RequestManagementSystem.Data.Models.Category", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("RequestManagementSystem.Data.Models.Department", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("RequestManagementSystem.Data.Models.Priority", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("RequestManagementSystem.Data.Models.Request", b =>
                {
                    b.Navigation("Actions");
                });

            modelBuilder.Entity("RequestManagementSystem.Data.Models.RequestStatus", b =>
                {
                    b.Navigation("Actions");

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("RequestManagementSystem.Data.Models.RequestType", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("RequestManagementSystem.Data.Models.User", b =>
                {
                    b.Navigation("CreatedRequests");

                    b.Navigation("ExecutedRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
