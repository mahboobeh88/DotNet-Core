using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiTesterV01.Migrations
{
    public partial class addUserTokenTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Company_CompanyId",
                table: "Pages");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionPage_Pages_PageId",
                table: "SectionPage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pages",
                table: "Pages");

            migrationBuilder.RenameTable(
                name: "Pages",
                newName: "Page");

            migrationBuilder.RenameIndex(
                name: "IX_Pages_CompanyId",
                table: "Page",
                newName: "IX_Page_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Page",
                table: "Page",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Page_Company_CompanyId",
                table: "Page",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionPage_Page_PageId",
                table: "SectionPage",
                column: "PageId",
                principalTable: "Page",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Page_Company_CompanyId",
                table: "Page");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionPage_Page_PageId",
                table: "SectionPage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Page",
                table: "Page");

            migrationBuilder.RenameTable(
                name: "Page",
                newName: "Pages");

            migrationBuilder.RenameIndex(
                name: "IX_Page_CompanyId",
                table: "Pages",
                newName: "IX_Pages_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pages",
                table: "Pages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Company_CompanyId",
                table: "Pages",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionPage_Pages_PageId",
                table: "SectionPage",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
