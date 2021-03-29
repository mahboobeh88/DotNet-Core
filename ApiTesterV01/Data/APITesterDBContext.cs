using ApiTesterV01.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Data
{
    public class APITesterDBContext : DbContext
    {
        public APITesterDBContext(DbContextOptions<APITesterDBContext> options) : base(options)
        {

        }
        #region Tabels
        public DbSet<Category> Category { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductDiscount> ProductDiscount { get; set; }
        public DbSet<CompanyOwner> CompanyOwner { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Discount> Discount { get; set; }
        public DbSet<Factory> Factory { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<SectionPage> SectionPage { get; set; }
        public DbSet<StoreHouse> StoreHouse { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<UserToken> UserToken { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyOwnerConfiguration());
            modelBuilder.ApplyConfiguration(new FactoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductDiscountConfiguration());
            modelBuilder.ApplyConfiguration(new MediaConfiguration());
            modelBuilder.ApplyConfiguration(new PageConfiguration());
            modelBuilder.ApplyConfiguration(new SectionPageConfiguration());
            modelBuilder.ApplyConfiguration(new DiscountConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new UnitConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new StoreHouseConfiguration());
            modelBuilder.ApplyConfiguration(new UserTokenConfiguration());
        }
    }
}
