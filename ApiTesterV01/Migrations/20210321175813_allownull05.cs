using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiTesterV01.Migrations
{
    public partial class allownull05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectionPage_Media_MediaId",
                table: "SectionPage");

            migrationBuilder.AlterColumn<long>(
                name: "MediaId",
                table: "SectionPage",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_SectionPage_Media_MediaId",
                table: "SectionPage",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectionPage_Media_MediaId",
                table: "SectionPage");

            migrationBuilder.AlterColumn<long>(
                name: "MediaId",
                table: "SectionPage",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionPage_Media_MediaId",
                table: "SectionPage",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
