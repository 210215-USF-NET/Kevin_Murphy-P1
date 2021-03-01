using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StoreDL.Entities
{
    public partial class StoreDBContext : DbContext
    {
        public StoreDBContext()
        {
        }

        public StoreDBContext(DbContextOptions<StoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarType> CarTypes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<StoreOrder> StoreOrders { get; set; }

     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CarType>(entity =>
            {
                entity.ToTable("carTypes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CarType1)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("carType");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CarType).HasColumnName("carType");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("customerName");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber");

                entity.HasOne(d => d.CarTypeNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CarType)
                    .HasConstraintName("FK__customers__carTy__02C769E9");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("inventories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InventoryName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("inventoryName");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.Product).HasColumnName("product");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.Location)
                    .HasConstraintName("FK__inventori__locat__2057CCD0");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK__inventori__produ__214BF109");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("locations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LocationAddress)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("locationAddress");

                entity.Property(e => e.LocationName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("locationName");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("orderItems");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Product).HasColumnName("product");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.StoreOrder).HasColumnName("storeOrder");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK__orderItem__produ__1C873BEC");

                entity.HasOne(d => d.StoreOrderNavigation)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.StoreOrder)
                    .HasConstraintName("FK__orderItem__store__1B9317B3");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProductDescription)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("productDescription");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("productName");

                entity.Property(e => e.ProductPrice).HasColumnName("productPrice");
            });

            modelBuilder.Entity<StoreOrder>(entity =>
            {
                entity.ToTable("storeOrders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Customer).HasColumnName("customer");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.StoreOrders)
                    .HasForeignKey(d => d.Customer)
                    .HasConstraintName("FK__storeOrde__custo__17C286CF");

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.StoreOrders)
                    .HasForeignKey(d => d.Location)
                    .HasConstraintName("FK__storeOrde__locat__18B6AB08");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
