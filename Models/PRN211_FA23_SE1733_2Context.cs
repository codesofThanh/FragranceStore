using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project.Models
{
    public partial class PRN211_FA23_SE1733_2Context : DbContext
    {
        public static PRN211_FA23_SE1733_2Context INSTANCE = new PRN211_FA23_SE1733_2Context();
        private PRN211_FA23_SE1733_2Context()
        {
            if (INSTANCE == null)
                INSTANCE = this;
        }

        public PRN211_FA23_SE1733_2Context(DbContextOptions<PRN211_FA23_SE1733_2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CartHe172748> CartHe172748s { get; set; } = null!;
        public virtual DbSet<CategoryHe172748> CategoryHe172748s { get; set; } = null!;
        public virtual DbSet<CustomerHe172748> CustomerHe172748s { get; set; } = null!;
        public virtual DbSet<EmployeeHe172748> EmployeeHe172748s { get; set; } = null!;
        public virtual DbSet<OrderDetailHe172748> OrderDetailHe172748s { get; set; } = null!;
        public virtual DbSet<OrderHe172748> OrderHe172748s { get; set; } = null!;
        public virtual DbSet<ProductHe172748> ProductHe172748s { get; set; } = null!;
        public virtual DbSet<ReviewHe172748> ReviewHe172748s { get; set; } = null!;
        public virtual DbSet<RoleHe172748> RoleHe172748s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).

                    AddJsonFile("appsettings.json", optional: false);

                IConfiguration con = builder.Build();
                string sql = con.GetConnectionString("MyCnn"); // chu y Strings hay String(cai nay dung)
                optionsBuilder.UseSqlServer(sql);

            }
        }

        public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<PRN211_FA23_SE1733_2Context>
        {
            public PRN211_FA23_SE1733_2Context CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<PRN211_FA23_SE1733_2Context>();
                optionsBuilder.UseSqlServer("server=DESKTOP-IM7U6MG;database=PRN211_FA23_SE1733_2;uid=sa;pwd=12345678;TrustServerCertificate=True");

                return new PRN211_FA23_SE1733_2Context(optionsBuilder.Options);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartHe172748>(entity =>
            {
                entity.ToTable("CartHE172748");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerCustomerId).HasColumnName("Customer_CustomerID");

                entity.Property(e => e.ProductId).HasColumnName("Product_id");

                entity.HasOne(d => d.CustomerCustomer)
                    .WithMany(p => p.CartHe172748s)
                    .HasForeignKey(d => d.CustomerCustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Cart_Customer");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartHe172748s)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Cart_Product");
            });

            modelBuilder.Entity<CategoryHe172748>(entity =>
            {
                entity.ToTable("CategoryHE172748");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cname)
                    .HasMaxLength(50)
                    .HasColumnName("cname");
            });

            modelBuilder.Entity<CustomerHe172748>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("Customer_pk");

                entity.ToTable("CustomerHE172748");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(45);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeHe172748>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("Employee_pk");

                entity.ToTable("EmployeeHE172748");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(45);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RoleRoleId).HasColumnName("Role_RoleID");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.RoleRole)
                    .WithMany(p => p.EmployeeHe172748s)
                    .HasForeignKey(d => d.RoleRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_Role");
            });

            modelBuilder.Entity<OrderDetailHe172748>(entity =>
            {
                entity.ToTable("OrderDetailHE172748");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OrderHe172748OrderId).HasColumnName("OrderHE172748_OrderId");

                entity.Property(e => e.ProductHe172748Id).HasColumnName("ProductHE172748_id");

                entity.Property(e => e.Tmp).HasColumnName("tmp");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(20, 2)");

                entity.HasOne(d => d.OrderHe172748Order)
                    .WithMany(p => p.OrderDetailHe172748s)
                    .HasForeignKey(d => d.OrderHe172748OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrderDetailHE172748_OrderHE172748");

                entity.HasOne(d => d.ProductHe172748)
                    .WithMany(p => p.OrderDetailHe172748s)
                    .HasForeignKey(d => d.ProductHe172748Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrderDetailHE172748_ProductHE172748");
            });

            modelBuilder.Entity<OrderHe172748>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("OrderHE172748_pk");

                entity.ToTable("OrderHE172748");

                entity.Property(e => e.CustomerHe172748CustomerId).HasColumnName("CustomerHE172748_CustomerID");

                entity.Property(e => e.Tmp).HasColumnName("tmp");

                entity.Property(e => e.Total).HasColumnType("decimal(20, 2)");

                entity.HasOne(d => d.CustomerHe172748Customer)
                    .WithMany(p => p.OrderHe172748s)
                    .HasForeignKey(d => d.CustomerHe172748CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrderHE172748_CustomerHE172748");
            });

            modelBuilder.Entity<ProductHe172748>(entity =>
            {
                entity.ToTable("ProductHE172748");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("Category_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.EmployeeEmployeeId).HasColumnName("Employee_EmployeeID");

                entity.Property(e => e.Img).HasColumnName("img");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(20, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.Tmp).HasColumnName("tmp");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductHe172748s)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Product_Category");

                entity.HasOne(d => d.EmployeeEmployee)
                    .WithMany(p => p.ProductHe172748s)
                    .HasForeignKey(d => d.EmployeeEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Product_Employee");
            });

            modelBuilder.Entity<ReviewHe172748>(entity =>
            {
                entity.ToTable("ReviewHE172748");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CreateOn).HasColumnType("datetime");

                entity.Property(e => e.CustomerCustomerId).HasColumnName("Customer_CustomerID");

                entity.Property(e => e.ProductId).HasColumnName("Product_id");

                entity.Property(e => e.Star).HasColumnName("star");

                entity.Property(e => e.Tmp).HasColumnName("tmp");

                entity.HasOne(d => d.CustomerCustomer)
                    .WithMany(p => p.ReviewHe172748s)
                    .HasForeignKey(d => d.CustomerCustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Review_Customer");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ReviewHe172748s)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Review_Product");
            });

            modelBuilder.Entity<RoleHe172748>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("RoleHE172748_pk");

                entity.ToTable("RoleHE172748");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
