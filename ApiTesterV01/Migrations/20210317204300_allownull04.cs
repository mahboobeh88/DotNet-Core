using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiTesterV01.Migrations
{
    public partial class allownull04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyOwner_City_CityId",
                table: "CompanyOwner");

            migrationBuilder.AlterColumn<short>(
                name: "CityId",
                table: "CompanyOwner",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyOwner_City_CityId",
                table: "CompanyOwner",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyOwner_City_CityId",
                table: "CompanyOwner");

            migrationBuilder.AlterColumn<short>(
                name: "CityId",
                table: "CompanyOwner",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyOwner_City_CityId",
                table: "CompanyOwner",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
