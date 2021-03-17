﻿// <auto-generated />
using System;
using ApiTesterV01.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiTesterV01.Migrations
{
    [DbContext(typeof(APITesterDBContext))]
    [Migration("20210317140049_createTbls")]
    partial class createTbls
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApiTesterV01.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.City", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProvinceName")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(150)");

                    b.Property<short>("CityId")
                        .HasColumnType("smallint");

                    b.Property<long>("CompanyOwnerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("RegisterDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<short>("Status")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CompanyOwnerId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.CompanyOwner", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<short>("CityId")
                        .HasColumnType("smallint");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MobileNo")
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("NationalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.Property<short>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((short)0);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("UserId");

                    b.ToTable("CompanyOwners");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<short>("CityId")
                        .HasColumnType("smallint");

                    b.Property<string>("CreditCardNumber")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("NationalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.Property<DateTime>("RegisterdateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<short>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((short)0);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("UserId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<float?>("Percent")
                        .HasColumnType("real");

                    b.Property<float?>("Price")
                        .HasColumnType("real");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.Factory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(150)");

                    b.Property<short>("CityId")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Factories");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.Media", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("File")
                        .HasColumnType("varbinary(8000)");

                    b.Property<short>("MediaType")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<string>("DeliveredAddress")
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(11)");

                    b.Property<long>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L);

                    b.Property<DateTime?>("RefundDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("RegisterDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<short>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((short)0);

                    b.Property<decimal>("TotalDiscount")
                        .HasColumnType("decimal(19,2)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(19,2)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.OrderDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<decimal>("DiscountPrice")
                        .HasColumnType("decimal(19,2)");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(19,2)");

                    b.Property<int>("ProductDiscountId")
                        .HasColumnType("int");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(19,2)");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductDiscountId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UnitId")
                        .IsUnique();

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.Page", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<string>("PageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<short>("PageType")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.Payment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<string>("DestinationCreditCard")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(19,2)");

                    b.Property<string>("RRN")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SourceCreditCard")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<short>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((short)0);

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ExpireDate")
                        .HasColumnType("datetime");

                    b.Property<int>("FactoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ManufacturedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(19,2)");

                    b.Property<int>("ProductUnitId")
                        .HasColumnType("int");

                    b.Property<short>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((short)0);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("FactoryId");

                    b.HasIndex("ProductUnitId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.ProductDiscount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<int>("DiscountId")
                        .HasColumnType("int");

                    b.Property<long?>("ProductId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DiscountId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductDiscounts");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.SectionPage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContentText")
                        .HasColumnType("nvarchar(500)");

                    b.Property<long>("MediaId")
                        .HasColumnType("bigint");

                    b.Property<long>("PageId")
                        .HasColumnType("bigint");

                    b.Property<short>("SectionType")
                        .HasColumnType("smallint");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("MediaId");

                    b.HasIndex("PageId");

                    b.ToTable("SectionPages");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.StoreHouse", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ComapnyId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("FirstInventory")
                        .HasColumnType("decimal(19,1)");

                    b.Property<DateTime>("InventoryEndDateTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("InventoryStartDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<short>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((short)0);

                    b.Property<short>("UnitId")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("ComapnyId")
                        .IsUnique();

                    b.HasIndex("ProductId");

                    b.ToTable("StoreHouses");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<short>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((short)0);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.Company", b =>
                {
                    b.HasOne("ApiTesterV01.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiTesterV01.Entities.CompanyOwner", "CompanyOwner")
                        .WithMany("Companies")
                        .HasForeignKey("CompanyOwnerId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("CompanyOwner");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.CompanyOwner", b =>
                {
                    b.HasOne("ApiTesterV01.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiTesterV01.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.Customer", b =>
                {
                    b.HasOne("ApiTesterV01.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiTesterV01.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.Factory", b =>
                {
                    b.HasOne("ApiTesterV01.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.Order", b =>
                {
                    b.HasOne("ApiTesterV01.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiTesterV01.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.OrderDetail", b =>
                {
                    b.HasOne("ApiTesterV01.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("ApiTesterV01.Entities.ProductDiscount", "ProductDiscount")
                        .WithMany()
                        .HasForeignKey("ProductDiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiTesterV01.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiTesterV01.Entities.Unit", "ProductUnit")
                        .WithOne("OrderDetail")
                        .HasForeignKey("ApiTesterV01.Entities.OrderDetail", "UnitId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");

                    b.Navigation("ProductDiscount");

                    b.Navigation("ProductUnit");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.Page", b =>
                {
                    b.HasOne("ApiTesterV01.Entities.Company", "Company")
                        .WithMany("Pages")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.Payment", b =>
                {
                    b.HasOne("ApiTesterV01.Entities.Customer", "Customer")
                        .WithMany("Payments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("ApiTesterV01.Entities.Order", "Order")
                        .WithOne("Payment")
                        .HasForeignKey("ApiTesterV01.Entities.Payment", "OrderId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.Product", b =>
                {
                    b.HasOne("ApiTesterV01.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("ApiTesterV01.Entities.Company", "Company")
                        .WithMany("Products")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("ApiTesterV01.Entities.Factory", "Factory")
                        .WithMany("Products")
                        .HasForeignKey("FactoryId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("ApiTesterV01.Entities.Unit", "Unit")
                        .WithMany("Products")
                        .HasForeignKey("ProductUnitId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Company");

                    b.Navigation("Factory");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.ProductDiscount", b =>
                {
                    b.HasOne("ApiTesterV01.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("ApiTesterV01.Entities.Discount", "Discount")
                        .WithMany()
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiTesterV01.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Customer");

                    b.Navigation("Discount");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.SectionPage", b =>
                {
                    b.HasOne("ApiTesterV01.Entities.Media", "Media")
                        .WithMany()
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiTesterV01.Entities.Page", "Page")
                        .WithMany("SectionPages")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Media");

                    b.Navigation("Page");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.StoreHouse", b =>
                {
                    b.HasOne("ApiTesterV01.Entities.Company", "Company")
                        .WithOne("StoreHouse")
                        .HasForeignKey("ApiTesterV01.Entities.StoreHouse", "ComapnyId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("ApiTesterV01.Entities.Product", "Product")
                        .WithMany("StoreHouses")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.Company", b =>
                {
                    b.Navigation("Pages");

                    b.Navigation("Products");

                    b.Navigation("StoreHouse");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.CompanyOwner", b =>
                {
                    b.Navigation("Companies");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.Customer", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.Factory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.Page", b =>
                {
                    b.Navigation("SectionPages");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.Product", b =>
                {
                    b.Navigation("StoreHouses");
                });

            modelBuilder.Entity("ApiTesterV01.Entities.Unit", b =>
                {
                    b.Navigation("OrderDetail");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
