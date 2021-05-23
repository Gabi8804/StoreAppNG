using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StoreApp.DataAccess.Entities
{
    public partial class SmartStoreDBContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public SmartStoreDBContext()
        {
        }

        public SmartStoreDBContext(DbContextOptions<SmartStoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<BrandCategory> BrandCategories { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategorySpec> CategorySpecs { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrdersProduct> OrdersProducts { get; set; }
        public virtual DbSet<ProdCatSpec> ProdCatSpecs { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Spec> Specs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=SmartStoreDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.AddressLine2).HasMaxLength(500);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Postcode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<BrandCategory>(entity =>
            {
                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.BrandCategories)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BrandCate__Brand__3A81B327");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.BrandCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BrandCate__Categ__3B75D760");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CategorySpec>(entity =>
            {
                entity.HasKey(e => e.CategorySpecsId)
                    .HasName("PK__Category__C0F6EFD97E5EFA6E");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategorySpecs)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CategoryS__Categ__3C69FB99");

                entity.HasOne(d => d.Spec)
                    .WithMany(p => p.CategorySpecs)
                    .HasForeignKey(d => d.SpecId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CategoryS__SpecI__3D5E1FD2");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Address");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_user");
            });

            modelBuilder.Entity<OrdersProduct>(entity =>
            {
                entity.HasKey(e => e.OrdersProductsId)
                    .HasName("PK__OrdersPr__F92EF86A0C24444F");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrdersProducts)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderProduct_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrdersProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderProduct_Product");
            });

            modelBuilder.Entity<ProdCatSpec>(entity =>
            {
                entity.ToTable("Prod_CatSpec");

                entity.Property(e => e.ProdCatSpecId).HasColumnName("Prod_CatSpecId");

                entity.Property(e => e.SpecValue)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.CategorySpecs)
                    .WithMany(p => p.ProdCatSpecs)
                    .HasForeignKey(d => d.CategorySpecsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Prod_CatS__Categ__4222D4EF");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProdCatSpecs)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Prod_CatS__Produ__4316F928");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Image).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.BrandCategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_BrandCategory");
            });

           
            modelBuilder.Entity<Spec>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            

            OnModelCreatingPartial(modelBuilder);
        }

        protected  void OnModelCreatingPartial(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }
    }
}
