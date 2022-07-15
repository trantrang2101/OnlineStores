using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace Assignment.Models
{
    public partial class HRManagementContext : DbContext
    {
        public HRManagementContext()
        {
        }

        public HRManagementContext(DbContextOptions<HRManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeStatus> EmployeeStatuses { get; set; }
        public virtual DbSet<Fine> Fines { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<StaffTask> StaffTasks { get; set; }
        public virtual DbSet<TaskInfo> TaskInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                string ConStr = config.GetConnectionString("ConStr");
                optionsBuilder.UseSqlServer(ConStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Name).HasMaxLength(32);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__AF2DBA79D4F47625");

                entity.ToTable("Employee");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Email).HasMaxLength(32);

                entity.Property(e => e.Fname)
                    .HasMaxLength(32)
                    .HasColumnName("FName");

                entity.Property(e => e.Holidays).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsAdmin)
                    .HasColumnName("isAdmin")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lname)
                    .HasMaxLength(32)
                    .HasColumnName("LName");

                entity.Property(e => e.Number).HasMaxLength(12);

                entity.Property(e => e.Password).HasMaxLength(128);

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Employee__Depart__286302EC");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK__Employee__Positi__29572725");
            });

            modelBuilder.Entity<EmployeeStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EmployeeStatus");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.LastAttend).HasColumnType("date");

                entity.HasOne(d => d.Emp)
                    .WithMany()
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__EmployeeS__EmpID__2D27B809");
            });

            modelBuilder.Entity<Fine>(entity =>
            {
                entity.ToTable("Fine");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Desc).HasMaxLength(1024);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.Fine1).HasColumnName("Fine");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Fines)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__Fine__EmpID__31EC6D26");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.Name).HasMaxLength(32);
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Salary");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.HasOne(d => d.Emp)
                    .WithMany()
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__Salary__EmpID__2F10007B");
            });

            modelBuilder.Entity<StaffTask>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("StaffTask");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.Emp)
                    .WithMany()
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__StaffTask__EmpID__36B12243");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK__StaffTask__id__35BCFE0A");
            });

            modelBuilder.Entity<TaskInfo>(entity =>
            {
                entity.ToTable("TaskInfo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Deadline).HasColumnType("smalldatetime");

                entity.Property(e => e.Desc).HasMaxLength(1024);

                entity.Property(e => e.Name).HasMaxLength(128);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
