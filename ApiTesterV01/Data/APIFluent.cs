using ApiTesterV01.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Data
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn();
            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("nvarchar(50)");
        }
    }
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn();
            builder.Property(c => c.Name)
                            .IsRequired()
                            .HasColumnType("nvarchar(50)");
            builder.Property(c => c.ProvinceName)
                .HasColumnType("nvarchar(50)");
        }
    }
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).UseIdentityColumn();
            builder.Property(d => d.Name)
                          .IsRequired()
                         .HasColumnType("nvarchar(50)");
            builder.Property(d => d.EndDate).HasColumnType("date");
            builder.Property(d => d.StartDate).HasColumnType("date");
        }
    }

    public class ProductDiscountConfiguration : IEntityTypeConfiguration<ProductDiscount>
    {
        public void Configure(EntityTypeBuilder<ProductDiscount> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.ProductId).HasColumnType("bigint");
            builder.Property(p => p.DiscountId).HasColumnType("int");
            builder.Property(p => p.CustomerId).HasColumnType("bigint");
        }
    }
    public class FactoryConfiguration : IEntityTypeConfiguration<Factory>
    {
        public void Configure(EntityTypeBuilder<Factory> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).UseIdentityColumn();
            builder.Property(f => f.Address).HasColumnType("nvarchar(150)");
            builder.Property(f => f.CityId).HasColumnType("smallint");
            builder.Property(f => f.Name).HasColumnType("nvarchar(100)");
            builder.Property(f => f.PhoneNumber).HasColumnType("nvarchar(50)");
            //builder.HasOne(f => f.CityId).WithOne<City>(c => c.Id).HasForeignKey<Factory>(f => f.CityId);

        }
    }
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).UseIdentityColumn();
            builder.Property(u => u.Name)
                .IsRequired()
                .HasColumnType("nvarchar(50)");
        }
    }
    public class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).UseIdentityColumn();
            builder.Property(m => m.Name)
                .IsRequired()
                .HasColumnType("nvarchar(50)");
            builder.Property(m => m.MediaType)
                .IsRequired()
                .HasColumnType("smallint");
            builder.Property(m => m.Url).HasColumnType("nvarchar(200)");
            builder.Property(m => m.File).HasColumnType("varbinary(8000)");
        }
    }
    public class PageConfiguration : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.CompanyId)
                .IsRequired()
                .HasColumnType("bigint");
            builder.Property(p => p.PageName)
                .IsRequired()
                .HasColumnType("nvarchar(50)");
            builder.Property(p => p.PageType)
                .IsRequired()
                .HasColumnType("smallint");
        }
    }
    public class SectionPageConfiguration : IEntityTypeConfiguration<SectionPage>
    {
        public void Configure(EntityTypeBuilder<SectionPage> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).UseIdentityColumn();
            builder.Property(s => s.PageId)
                .IsRequired()
                .HasColumnType("bigint");
            builder.Property(s => s.SectionType)
                .IsRequired()
                .HasColumnType("smallint");
            builder.Property(s => s.ContentText).HasColumnType("nvarchar(500)");
            builder.Property(s => s.MediaId).HasColumnType("bigint");
            builder.Property(s => s.Title).HasColumnType("nvarchar(50)");
        }
    }

    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn();
            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("nvarchar(50)");
            builder.Property(c => c.AccountNumber).HasColumnType("nvarchar(30)");
            builder.Property(c => c.Address).HasColumnType("nvarchar(150)");
            builder.Property(c => c.PhoneNumber).HasColumnType("nvarchar(50)");
            builder.Property(c => c.RegisterDateTime).HasDefaultValueSql("GetDate()").HasColumnType("DateTime");
            builder.Property(c => c.Status).HasColumnType("smallint");
            builder.Property(c => c.CompanyOwnerId).HasColumnType("bigint");
            builder.HasOne(c => c.StoreHouse)
                .WithOne(c => c.Company)
                .HasForeignKey<StoreHouse>(c => c.ComapnyId)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }

    public class CompanyOwnerConfiguration : IEntityTypeConfiguration<CompanyOwner>
    {
        public void Configure(EntityTypeBuilder<CompanyOwner> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn();
            builder.Property(c => c.FirstName).HasColumnType("nvarchar(50)");
            builder.Property(c => c.LastName).HasColumnType("nvarchar(50)");
            builder.Property(c => c.MobileNo).HasColumnType("nvarchar(11)");
            builder.Property(c => c.NationalId)
                .IsRequired()
                .HasColumnType("nvarchar(13)");
            builder.Property(c => c.Status)
                .HasColumnType("smallint")
                .HasDefaultValue(0);
            builder.Property(c => c.UserId)
                .IsRequired()
                .HasColumnType("uniqueidentifier");
            builder.Property(c => c.CityId).HasColumnType("smallint");
            builder.Property(c => c.BirthDate).HasColumnType("date");
            builder.HasMany(c => c.Companies).WithOne(o => o.CompanyOwner)
                .HasForeignKey(o => o.CompanyOwnerId)
                .OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasOne(o => o.User)
                        .WithOne(p => p.companyOwner)
                        .HasForeignKey<CompanyOwner>(o => o.UserId)
                        .OnDelete(DeleteBehavior.ClientNoAction);



        }

    }
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("uniqueidentifier");
            builder.Property(u => u.UserName)
                .IsRequired()
                .HasColumnType("nvarchar(50)");
            builder.Property(u => u.Password)
                .IsRequired()
                .HasColumnType("nvarchar(150)");
            builder.Property(u => u.PasswordSalt)
               .HasColumnType("uniqueidentifier");
            builder.Property(u => u.Status)
                .HasColumnType("smallint")
                .HasDefaultValue(0);
            builder.Property(u => u.IsActive)
                .HasColumnType("bit")
                .HasDefaultValue(0);
           

        }
    }
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn().HasColumnType("bigint");
            builder.Property(c => c.FirstName).HasColumnType("nvarchar(50)");
            builder.Property(c => c.LastName).HasColumnType("nvarchar(50)");
            builder.Property(c => c.Mobile).HasColumnType("nvarchar(11)");
            builder.Property(c => c.NationalId)
                .IsRequired()
                .HasColumnType("nvarchar(13)");
            builder.Property(c => c.Status).HasColumnType("smallint").HasDefaultValue(0);
            builder.Property(c => c.UserId)
                .IsRequired()
                .HasColumnType("uniqueidentifier");
            builder.Property(c => c.CityId).HasColumnType("smallint");
            builder.Property(c => c.BirthDate).HasColumnType("date");
            builder.Property(c => c.RegisterdateTime)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GetDate()");
            builder.Property(c => c.CreditCardNumber).HasColumnType("nvarchar(30)");
            builder.Property(c => c.Address).HasColumnType("nvarchar(150)");
            builder.HasOne(o => o.User)
                       .WithOne(p => p.customer)
                       .HasForeignKey<Customer>(o => o.UserId)
                       .OnDelete(DeleteBehavior.ClientNoAction);

        }
    }

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).UseIdentityColumn();
            builder.Property(o => o.CompanyId).HasColumnType("bigint");
            builder.Property(o => o.CustomerId)
                .IsRequired()
                .HasColumnType("bigint");
            builder.Property(o => o.DeliveryDate).HasColumnType("datetime");
            builder.Property(o => o.DeliveredAddress)
               .HasColumnType("nvarchar(150)");
            builder.Property(o => o.Status)
                .HasColumnType("smallint")
                .HasDefaultValue(0);
            builder.Property(o => o.Mobile).HasColumnType("nvarchar(11)");
            builder.Property(o => o.PaymentId)
                .HasColumnType("bigint")
                .HasDefaultValue(0);
            builder.Property(o => o.RefundDate).HasColumnType("datetime");
            builder.Property(o => o.RegisterDateTime)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GetDate()");
            builder.Property(o => o.TotalDiscount).HasColumnType("decimal(19,2)");
            builder.Property(o => o.TotalPrice).HasColumnType("decimal(19,2)");
            builder.HasOne(p => p.Customer).WithMany(b => b.Orders)
              .HasForeignKey(p => p.CustomerId)
              .OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasOne(o => o.Payment)
                            .WithOne(p => p.Order)
                            .HasForeignKey<Order>(o => o.PaymentId)
                            .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }

    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(od => od.Id);
            builder.Property(od => od.Id).UseIdentityColumn();
            builder.Property(od => od.ProductId)
                .IsRequired()
                .HasColumnType("bigint");
            builder.Property(od => od.ProductDiscountId).HasColumnType("int");
            builder.Property(od => od.UnitId).HasColumnType("int");
            builder.Property(od => od.OrderId).HasColumnType("bigint");
            builder.Property(od => od.Price).IsRequired().HasColumnType("decimal(19,2)");
            builder.Property(od => od.TotalPrice).HasColumnType("decimal(19,2)");
            builder.Property(od => od.DiscountPrice).HasColumnType("decimal(19,2)");
            builder.Property(od => od.Count).HasColumnType("int");
            builder.HasOne(p => p.Order).WithMany(b => b.OrderDetails)
           .HasForeignKey(p => p.OrderId)
           .OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasOne(p => p.ProductUnit).WithOne(b => b.OrderDetail)
            .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.ManufacturedDate).HasColumnType("date");
            builder.Property(p => p.CategoryId)
                .IsRequired()
                .HasColumnType("int");
            builder.Property(p => p.CompanyId)
                .IsRequired()
                .HasColumnType("bigint");
            builder.Property(p => p.ExpireDate).HasColumnType("date");
            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(19,2)");
            builder.Property(p => p.FactoryId).HasColumnType("int");
            builder.Property(p => p.Name)
                    .IsRequired()
                    .HasColumnType("nvarchar(50)");
            builder.Property(p => p.ProductUnitId).HasColumnType("int");
            builder.Property(p => p.Status)
                    .HasColumnType("smallint")
                    .HasDefaultValue(0);
            builder.HasOne(c => c.Category).WithMany(b => b.Products)
                    .HasForeignKey(b => b.CategoryId)
                    .OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasOne(c => c.Company).WithMany(b => b.Products)
                   .HasForeignKey(c => c.CompanyId)
                   .OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasOne(c => c.Unit).WithMany(b => b.Products)
                  .HasForeignKey(c => c.ProductUnitId)
                  .OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasOne(c => c.Factory).WithMany(b => b.Products)
             .HasForeignKey(c => c.FactoryId)
             .OnDelete(DeleteBehavior.ClientNoAction);

        }
    }

    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.OrderId)
                .IsRequired()
                .HasColumnType("bigint");
            builder.Property(p => p.SourceCreditCard)
                .IsRequired()
                .HasColumnType("nvarchar(30)");
            builder.Property(p => p.DestinationCreditCard)
                .IsRequired()
                .HasColumnType("nvarchar(30)");
            builder.Property(p => p.CustomerId)
                .IsRequired()
                .HasColumnType("bigint");
            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(19,2)");
            builder.Property(p => p.RRN).HasColumnType("nvarchar(50)");
            builder.Property(p => p.PaymentDate).HasColumnType("datetime");
            builder.Property(p => p.Status)
                .HasColumnType("smallint")
                .HasDefaultValue(0);
            builder.HasOne(c => c.Order)
                .WithOne(b => b.Payment)
              .HasForeignKey<Payment>(o => o.OrderId)
             .OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasOne(c => c.Customer)
                            .WithMany(b => b.Payments)
                                 .HasForeignKey(c => c.CustomerId)
                                 .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
public class StoreHouseConfiguration : IEntityTypeConfiguration<StoreHouse>
{
    public void Configure(EntityTypeBuilder<StoreHouse> builder)
    {
        builder.HasKey(sh => sh.Id);
        builder.Property(sh => sh.Id).UseIdentityColumn();
        builder.Property(sh => sh.ProductId)
            .IsRequired()
            .HasColumnType("bigint");
        builder.Property(sh => sh.FirstInventory)
            .IsRequired()
            .HasColumnType("decimal(19,1)");
        builder.Property(sh => sh.InventoryStartDateTime)
            .IsRequired()
            .HasColumnType("datetime")
            .HasDefaultValueSql("GetDate()");
        builder.Property(sh => sh.InventoryEndDateTime).HasColumnType("datetime");
        builder.Property(sh => sh.UnitId).HasColumnType("smallint");
        builder.Property(sh => sh.ComapnyId)
            .IsRequired()
            .HasColumnType("bigint");
        builder.Property(sh => sh.Status)
            .HasColumnType("smallint")
            .HasDefaultValue(0);
        builder.HasOne(c => c.Product).WithMany(b => b.StoreHouses)
              .HasForeignKey(c => c.ProductId)
              .OnDelete(DeleteBehavior.ClientNoAction);
        //builder.HasOne(c => c.Company).WithOne(b => b.StoreHouse)
        //    .HasForeignKey<StoreHouse>(s => s.ComapnyId)
        //    .OnDelete(DeleteBehavior.ClientNoAction);


    }
}


