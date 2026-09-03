using System;
using CertEasy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CertEasy.Data.Migrations
{
    [DbContext(typeof(CertEasyDbContext))]
    partial class CertEasyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CertEasy.Model.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Accounts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "admin@certeasy.local",
                            Status = 1,
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            UserID = 1,
                            UserName = "admin@certeasy.local"
                        });
                });

            modelBuilder.Entity("CertEasy.Model.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City").HasColumnType("nvarchar(max)");
                    b.Property<string>("Country").HasColumnType("nvarchar(max)");
                    b.Property<string>("CreatedBy").HasColumnType("nvarchar(max)");
                    b.Property<DateTime>("CreatedDate").HasColumnType("datetime2");
                    b.Property<string>("Line1").HasColumnType("nvarchar(max)");
                    b.Property<string>("Line2").HasColumnType("nvarchar(max)");
                    b.Property<string>("State").HasColumnType("nvarchar(max)");
                    b.Property<string>("UpdatedBy").HasColumnType("nvarchar(max)");
                    b.Property<DateTime?>("UpdatedDate").HasColumnType("datetime2");
                    b.Property<string>("ZipCode").HasColumnType("nvarchar(max)");

                    b.HasKey("Id");
                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("CertEasy.Model.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CertificationID").HasColumnType("int");
                    b.Property<string>("CreatedBy").HasColumnType("nvarchar(max)");
                    b.Property<DateTime>("CreatedDate").HasColumnType("datetime2");
                    b.Property<int>("EducationLevelID").HasColumnType("int");
                    b.Property<int?>("ExamID").HasColumnName("ExamID").HasColumnType("int");
                    b.Property<string>("Remarks").HasColumnType("nvarchar(max)");
                    b.Property<int>("StatusID").HasColumnType("int");
                    b.Property<DateTime>("SubmittedDate").HasColumnType("datetime2");
                    b.Property<string>("UpdatedBy").HasColumnType("nvarchar(max)");
                    b.Property<DateTime?>("UpdatedDate").HasColumnType("datetime2");
                    b.Property<int>("UserID").HasColumnType("int");

                    b.HasKey("Id");
                    b.HasIndex("ExamID");
                    b.HasIndex("StatusID");
                    b.HasIndex("UserID");
                    b.ToTable("Applications", (string)null);
                });

            modelBuilder.Entity("CertEasy.Model.Certification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy").HasColumnType("nvarchar(max)");
                    b.Property<DateTime>("CreatedDate").HasColumnType("datetime2");
                    b.Property<string>("Description").HasMaxLength(500).HasColumnType("nvarchar(500)");
                    b.Property<bool>("IsActive").HasColumnType("bit");
                    b.Property<string>("Name").IsRequired().HasMaxLength(100).HasColumnType("nvarchar(100)");
                    b.Property<string>("UpdatedBy").HasColumnType("nvarchar(max)");
                    b.Property<DateTime?>("UpdatedDate").HasColumnType("datetime2");

                    b.HasKey("Id");
                    b.ToTable("Certifications");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Description = "Leading safety certification",
                            IsActive = true,
                            Name = "Certified Safety Professional (CSP)",
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Description = "Entry-level safety certification",
                            IsActive = true,
                            Name = "Associate Safety Professional (ASP)",
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("CertEasy.Model.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy").HasMaxLength(100).HasColumnType("nvarchar(100)");
                    b.Property<DateTime>("CreatedDate").HasColumnType("datetime2");
                    b.Property<string>("Description").HasMaxLength(500).HasColumnType("nvarchar(500)");
                    b.Property<string>("InstituteName").HasMaxLength(200).HasColumnType("nvarchar(200)");
                    b.Property<bool>("IsActive").HasColumnType("bit");
                    b.Property<string>("Name").HasMaxLength(100).HasColumnType("nvarchar(100)");
                    b.Property<string>("UpdatedBy").HasMaxLength(100).HasColumnType("nvarchar(100)");
                    b.Property<DateTime?>("UpdatedDate").HasColumnType("datetime2");

                    b.HasKey("Id");
                    b.ToTable("Educations", (string)null);
                });

            modelBuilder.Entity("CertEasy.Model.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExamCenter")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ExamName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("ExamSlot")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Exams", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            ExamCenter = "New York Testing Center",
                            ExamName = "Spring 2024 Exam Session",
                            ExamSlot = new DateTime(2024, 4, 15, 10, 0, 0, 0, DateTimeKind.Utc),
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            ExamCenter = "Chicago Testing Center",
                            ExamName = "Spring 2024 Exam Session",
                            ExamSlot = new DateTime(2024, 4, 16, 14, 0, 0, 0, DateTimeKind.Utc),
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("CertEasy.Model.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Action").HasColumnType("nvarchar(max)");
                    b.Property<string>("CreatedBy").HasColumnType("nvarchar(max)");
                    b.Property<DateTime>("CreatedDate").HasColumnType("datetime2");
                    b.Property<string>("Details").HasColumnType("nvarchar(max)");
                    b.Property<string>("EntityName").HasColumnType("nvarchar(max)");
                    b.Property<string>("UpdatedBy").HasColumnType("nvarchar(max)");
                    b.Property<DateTime?>("UpdatedDate").HasColumnType("datetime2");
                    b.Property<int?>("UserID").HasColumnType("int");

                    b.HasKey("Id");
                    b.ToTable("AppLogs", (string)null);
                });

            modelBuilder.Entity("CertEasy.Model.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy").HasColumnType("nvarchar(max)");
                    b.Property<DateTime>("CreatedDate").HasColumnType("datetime2");
                    b.Property<string>("Description").HasColumnType("nvarchar(max)");
                    b.Property<string>("RoleName").HasColumnType("nvarchar(max)");
                    b.Property<string>("UpdatedBy").HasColumnType("nvarchar(max)");
                    b.Property<DateTime?>("UpdatedDate").HasColumnType("datetime2");

                    b.HasKey("Id");
                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Description = "Administrator with full access",
                            RoleName = "Admin",
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Description = "Regular user with limited access",
                            RoleName = "User",
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("CertEasy.Model.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy").HasColumnType("nvarchar(max)");
                    b.Property<DateTime>("CreatedDate").HasColumnType("datetime2");
                    b.Property<string>("StatusName").HasColumnType("nvarchar(max)");
                    b.Property<string>("UpdatedBy").HasColumnType("nvarchar(max)");
                    b.Property<DateTime?>("UpdatedDate").HasColumnType("datetime2");

                    b.HasKey("Id");
                    b.ToTable("Statuses", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            StatusName = "New",
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            StatusName = "User Profile",
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            StatusName = "Certification Selection",
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            StatusName = "Educational Qualification",
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 5,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            StatusName = "Invoice",
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 6,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            StatusName = "Review",
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 7,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            StatusName = "Approved",
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 8,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            StatusName = "Rejection",
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("CertEasy.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AddressID").HasColumnType("int");
                    b.Property<string>("CreatedBy").HasColumnType("nvarchar(max)");
                    b.Property<DateTime>("CreatedDate").HasColumnType("datetime2");
                    b.Property<string>("Email").IsRequired().HasColumnType("nvarchar(max)");
                    b.Property<string>("FirstName").IsRequired().HasColumnType("nvarchar(max)");
                    b.Property<string>("LastName").IsRequired().HasColumnType("nvarchar(max)");
                    b.Property<string>("PasswordHash").IsRequired().HasColumnType("nvarchar(max)");
                    b.Property<int>("RoleID").HasColumnType("int");
                    b.Property<int>("StatusID").HasColumnType("int");
                    b.Property<string>("UpdatedBy").HasColumnType("nvarchar(max)");
                    b.Property<DateTime?>("UpdatedDate").HasColumnType("datetime2");

                    b.HasKey("Id");
                    b.HasIndex("AddressID");
                    b.HasIndex("RoleID");
                    b.HasIndex("StatusID");
                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressID = (int?)null,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "admin@certeasy.local",
                            FirstName = "System",
                            LastName = "Admin",
                            PasswordHash = "AQAAAAEAACcQAAAAEPvH/9R7xK9n8x5...",
                            RoleID = 1,
                            StatusID = 1,
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("CertEasy.Model.Account", b =>
                {
                    b.HasOne("CertEasy.Model.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("CertEasy.Model.Account", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CertEasy.Model.Application", b =>
                {
                    b.HasOne("CertEasy.Model.Exam", "Exam")
                        .WithMany()
                        .HasForeignKey("ExamID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("CertEasy.Model.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CertEasy.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Exam");
                    b.Navigation("Status");
                    b.Navigation("User");
                });

            modelBuilder.Entity("CertEasy.Model.User", b =>
                {
                    b.HasOne("CertEasy.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID");

                    b.HasOne("CertEasy.Model.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CertEasy.Model.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                    b.Navigation("Role");
                    b.Navigation("Status");
                });

            modelBuilder.Entity("CertEasy.Model.User", b =>
                {
                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}
