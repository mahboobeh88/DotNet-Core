using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiTesterV01.Migrations
{
    public partial class singularTbls_paymnetForiegnKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Cities_CityId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_CompanyOwners_CompanyOwnerId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyOwners_Cities_CityId",
                table: "CompanyOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyOwners_Users_UserId",
                table: "CompanyOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Cities_CityId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_UserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Factories_Cities_CityId",
                table: "Factories");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_ProductDiscounts_ProductDiscountId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Units_UnitId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Companies_CompanyId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Companies_CompanyId",
                table: "Pages");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Customers_CustomerId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDiscounts_Customers_CustomerId",
                table: "ProductDiscounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDiscounts_Discounts_DiscountId",
                table: "ProductDiscounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDiscounts_Products_ProductId",
                table: "ProductDiscounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Factories_FactoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Units_ProductUnitId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionPages_Medias_MediaId",
                table: "SectionPages");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionPages_Pages_PageId",
                table: "SectionPages");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreHouses_Companies_ComapnyId",
                table: "StoreHouses");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreHouses_Products_ProductId",
                table: "StoreHouses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Units",
                table: "Units");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreHouses",
                table: "StoreHouses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SectionPages",
                table: "SectionPages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDiscounts",
                table: "ProductDiscounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medias",
                table: "Medias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Factories",
                table: "Factories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discounts",
                table: "Discounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyOwners",
                table: "CompanyOwners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Units",
                newName: "Unit");

            migrationBuilder.RenameTable(
                name: "StoreHouses",
                newName: "StoreHouse");

            migrationBuilder.RenameTable(
                name: "SectionPages",
                newName: "SectionPage");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "ProductDiscounts",
                newName: "ProductDiscount");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "Payment");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                newName: "OrderDetail");

            migrationBuilder.RenameTable(
                name: "Medias",
                newName: "Media");

            migrationBuilder.RenameTable(
                name: "Factories",
                newName: "Factory");

            migrationBuilder.RenameTable(
                name: "Discounts",
                newName: "Discount");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "CompanyOwners",
                newName: "CompanyOwner");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_StoreHouses_ProductId",
                table: "StoreHouse",
                newName: "IX_StoreHouse_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_StoreHouses_ComapnyId",
                table: "StoreHouse",
                newName: "IX_StoreHouse_ComapnyId");

            migrationBuilder.RenameIndex(
                name: "IX_SectionPages_PageId",
                table: "SectionPage",
                newName: "IX_SectionPage_PageId");

            migrationBuilder.RenameIndex(
                name: "IX_SectionPages_MediaId",
                table: "SectionPage",
                newName: "IX_SectionPage_MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductUnitId",
                table: "Product",
                newName: "IX_Product_ProductUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_FactoryId",
                table: "Product",
                newName: "IX_Product_FactoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CompanyId",
                table: "Product",
                newName: "IX_Product_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDiscounts_ProductId",
                table: "ProductDiscount",
                newName: "IX_ProductDiscount_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDiscounts_DiscountId",
                table: "ProductDiscount",
                newName: "IX_ProductDiscount_DiscountId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDiscounts_CustomerId",
                table: "ProductDiscount",
                newName: "IX_ProductDiscount_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_OrderId",
                table: "Payment",
                newName: "IX_Payment_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_CustomerId",
                table: "Payment",
                newName: "IX_Payment_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                table: "Order",
                newName: "IX_Order_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CompanyId",
                table: "Order",
                newName: "IX_Order_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_UnitId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_ProductDiscountId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_ProductDiscountId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Factories_CityId",
                table: "Factory",
                newName: "IX_Factory_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_UserId",
                table: "Customer",
                newName: "IX_Customer_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_CityId",
                table: "Customer",
                newName: "IX_Customer_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyOwners_UserId",
                table: "CompanyOwner",
                newName: "IX_CompanyOwner_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyOwners_CityId",
                table: "CompanyOwner",
                newName: "IX_CompanyOwner_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_CompanyOwnerId",
                table: "Company",
                newName: "IX_Company_CompanyOwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_CityId",
                table: "Company",
                newName: "IX_Company_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Unit",
                table: "Unit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreHouse",
                table: "StoreHouse",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SectionPage",
                table: "SectionPage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDiscount",
                table: "ProductDiscount",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                table: "Payment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Media",
                table: "Media",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Factory",
                table: "Factory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discount",
                table: "Discount",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyOwner",
                table: "CompanyOwner",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_City_CityId",
                table: "Company",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_CompanyOwner_CompanyOwnerId",
                table: "Company",
                column: "CompanyOwnerId",
                principalTable: "CompanyOwner",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyOwner_City_CityId",
                table: "CompanyOwner",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyOwner_User_UserId",
                table: "CompanyOwner",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_City_CityId",
                table: "Customer",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_User_UserId",
                table: "Customer",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Factory_City_CityId",
                table: "Factory",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Company_CompanyId",
                table: "Order",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Product_ProductId",
                table: "OrderDetail",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_ProductDiscount_ProductDiscountId",
                table: "OrderDetail",
                column: "ProductDiscountId",
                principalTable: "ProductDiscount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Unit_UnitId",
                table: "OrderDetail",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Company_CompanyId",
                table: "Pages",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Customer_CustomerId",
                table: "Payment",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Order_OrderId",
                table: "Payment",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Company_CompanyId",
                table: "Product",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Factory_FactoryId",
                table: "Product",
                column: "FactoryId",
                principalTable: "Factory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Unit_ProductUnitId",
                table: "Product",
                column: "ProductUnitId",
                principalTable: "Unit",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDiscount_Customer_CustomerId",
                table: "ProductDiscount",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDiscount_Discount_DiscountId",
                table: "ProductDiscount",
                column: "DiscountId",
                principalTable: "Discount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDiscount_Product_ProductId",
                table: "ProductDiscount",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionPage_Media_MediaId",
                table: "SectionPage",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionPage_Pages_PageId",
                table: "SectionPage",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreHouse_Company_ComapnyId",
                table: "StoreHouse",
                column: "ComapnyId",
                principalTable: "Company",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreHouse_Product_ProductId",
                table: "StoreHouse",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_City_CityId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_CompanyOwner_CompanyOwnerId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyOwner_City_CityId",
                table: "CompanyOwner");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyOwner_User_UserId",
                table: "CompanyOwner");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_City_CityId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_User_UserId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Factory_City_CityId",
                table: "Factory");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Company_CompanyId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Product_ProductId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_ProductDiscount_ProductDiscountId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Unit_UnitId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Company_CompanyId",
                table: "Pages");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Customer_CustomerId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Order_OrderId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Company_CompanyId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Factory_FactoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Unit_ProductUnitId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDiscount_Customer_CustomerId",
                table: "ProductDiscount");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDiscount_Discount_DiscountId",
                table: "ProductDiscount");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDiscount_Product_ProductId",
                table: "ProductDiscount");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionPage_Media_MediaId",
                table: "SectionPage");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionPage_Pages_PageId",
                table: "SectionPage");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreHouse_Company_ComapnyId",
                table: "StoreHouse");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreHouse_Product_ProductId",
                table: "StoreHouse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Unit",
                table: "Unit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreHouse",
                table: "StoreHouse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SectionPage",
                table: "SectionPage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDiscount",
                table: "ProductDiscount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Media",
                table: "Media");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Factory",
                table: "Factory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discount",
                table: "Discount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyOwner",
                table: "CompanyOwner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Unit",
                newName: "Units");

            migrationBuilder.RenameTable(
                name: "StoreHouse",
                newName: "StoreHouses");

            migrationBuilder.RenameTable(
                name: "SectionPage",
                newName: "SectionPages");

            migrationBuilder.RenameTable(
                name: "ProductDiscount",
                newName: "ProductDiscounts");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Payment",
                newName: "Payments");

            migrationBuilder.RenameTable(
                name: "OrderDetail",
                newName: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Media",
                newName: "Medias");

            migrationBuilder.RenameTable(
                name: "Factory",
                newName: "Factories");

            migrationBuilder.RenameTable(
                name: "Discount",
                newName: "Discounts");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "CompanyOwner",
                newName: "CompanyOwners");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Cities");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_StoreHouse_ProductId",
                table: "StoreHouses",
                newName: "IX_StoreHouses_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_StoreHouse_ComapnyId",
                table: "StoreHouses",
                newName: "IX_StoreHouses_ComapnyId");

            migrationBuilder.RenameIndex(
                name: "IX_SectionPage_PageId",
                table: "SectionPages",
                newName: "IX_SectionPages_PageId");

            migrationBuilder.RenameIndex(
                name: "IX_SectionPage_MediaId",
                table: "SectionPages",
                newName: "IX_SectionPages_MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDiscount_ProductId",
                table: "ProductDiscounts",
                newName: "IX_ProductDiscounts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDiscount_DiscountId",
                table: "ProductDiscounts",
                newName: "IX_ProductDiscounts_DiscountId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDiscount_CustomerId",
                table: "ProductDiscounts",
                newName: "IX_ProductDiscounts_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductUnitId",
                table: "Products",
                newName: "IX_Products_ProductUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_FactoryId",
                table: "Products",
                newName: "IX_Products_FactoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CompanyId",
                table: "Products",
                newName: "IX_Products_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_OrderId",
                table: "Payments",
                newName: "IX_Payments_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_CustomerId",
                table: "Payments",
                newName: "IX_Payments_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_UnitId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_ProductDiscountId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_ProductDiscountId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CustomerId",
                table: "Orders",
                newName: "IX_Orders_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CompanyId",
                table: "Orders",
                newName: "IX_Orders_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Factory_CityId",
                table: "Factories",
                newName: "IX_Factories_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_UserId",
                table: "Customers",
                newName: "IX_Customers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_CityId",
                table: "Customers",
                newName: "IX_Customers_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyOwner_UserId",
                table: "CompanyOwners",
                newName: "IX_CompanyOwners_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyOwner_CityId",
                table: "CompanyOwners",
                newName: "IX_CompanyOwners_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Company_CompanyOwnerId",
                table: "Companies",
                newName: "IX_Companies_CompanyOwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Company_CityId",
                table: "Companies",
                newName: "IX_Companies_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Units",
                table: "Units",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreHouses",
                table: "StoreHouses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SectionPages",
                table: "SectionPages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDiscounts",
                table: "ProductDiscounts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medias",
                table: "Medias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Factories",
                table: "Factories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discounts",
                table: "Discounts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyOwners",
                table: "CompanyOwners",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Cities_CityId",
                table: "Companies",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_CompanyOwners_CompanyOwnerId",
                table: "Companies",
                column: "CompanyOwnerId",
                principalTable: "CompanyOwners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyOwners_Cities_CityId",
                table: "CompanyOwners",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyOwners_Users_UserId",
                table: "CompanyOwners",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Cities_CityId",
                table: "Customers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_UserId",
                table: "Customers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Factories_Cities_CityId",
                table: "Factories",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_ProductDiscounts_ProductDiscountId",
                table: "OrderDetails",
                column: "ProductDiscountId",
                principalTable: "ProductDiscounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                table: "OrderDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Units_UnitId",
                table: "OrderDetails",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Companies_CompanyId",
                table: "Orders",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Companies_CompanyId",
                table: "Pages",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Customers_CustomerId",
                table: "Payments",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDiscounts_Customers_CustomerId",
                table: "ProductDiscounts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDiscounts_Discounts_DiscountId",
                table: "ProductDiscounts",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDiscounts_Products_ProductId",
                table: "ProductDiscounts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Factories_FactoryId",
                table: "Products",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Units_ProductUnitId",
                table: "Products",
                column: "ProductUnitId",
                principalTable: "Units",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SectionPages_Medias_MediaId",
                table: "SectionPages",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionPages_Pages_PageId",
                table: "SectionPages",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreHouses_Companies_ComapnyId",
                table: "StoreHouses",
                column: "ComapnyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreHouses_Products_ProductId",
                table: "StoreHouses",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
