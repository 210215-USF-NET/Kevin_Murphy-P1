using Microsoft.EntityFrameworkCore;
using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDL
{
    public class StoreDBContext : DbContext
    {
        public StoreDBContext( DbContextOptions options) : base(options)
        {
        }

        protected StoreDBContext()
        {
        }
        public DbSet<Customer> Customers{ get; set; } 

        public DbSet<Product> Products { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Orderline> Orderlines { get; set; }
       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            //addition of customer IDS(self-incrementation)
            modelBuilder.Entity<Customer>()
                .Property(customer => customer.Id)
                .ValueGeneratedOnAdd();

            // one to many with orders
            modelBuilder.Entity<Customer>()
                .HasMany(customer => customer.Orders)
                .WithOne(order => order.Customer);


            //Products Overloads
            modelBuilder.Entity<Product>()
                .Property(product => product.PId)
                .ValueGeneratedOnAdd();

            //location overloads
            modelBuilder.Entity<Location>()
                .Property(location => location.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Location>()
                .HasMany(location => location.Orders)
                .WithOne(order => order.Location);

            //inventory
            modelBuilder.Entity<Inventory>()
                .Property(inventory => inventory.ID)
                .ValueGeneratedOnAdd();
*/            /*
                        modelBuilder.Entity<Inventory>()
                            .HasKey(inventory => new { inventory.Location, inventory.Product });*//*

                        modelBuilder.Entity<Inventory>()
                            .HasOne(inventory => inventory.Product)
                            .WithMany(product => product.Inventories)
                            .HasForeignKey(inventory => inventory.Product.PId);

                        modelBuilder.Entity<Inventory>()
                            .HasOne(inventory => inventory.Location)
                            .WithMany(location => location.Inventories)
                            .HasForeignKey(inventory => inventory.Location);


                        //Order overloads
                        modelBuilder.Entity<Order>()
                            .Property(order => order.Id)
                            .ValueGeneratedOnAdd();

                        //orderline overloads

                        modelBuilder.Entity<Orderline>()
                            .Property(orderline => orderline.ID)
                            .ValueGeneratedOnAdd();

               *//*         modelBuilder.Entity<Orderline>()
                            .HasKey(orderline => new { orderline.Order.Id, orderline.Product.PId});*//*


                        modelBuilder.Entity<Orderline>()
                            .HasOne(orderline => orderline.Product)
                            .WithMany(order => order.Orderlines)
                            .HasForeignKey(orderline => orderline.Order.Id);

                        modelBuilder.Entity<Orderline>()
                            .HasOne(orderline => orderline.Product)
                            .WithMany(product => product.Orderlines)
                            .HasForeignKey(orderline => orderline.Product.PId);






                    }*/
        }
    }
