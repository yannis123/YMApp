using Microsoft.EntityFrameworkCore.Migrations;

namespace YMApp.Migrations
{
    public partial class updatetrip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Categorys_CategoryId",
                table: "Trips");

            migrationBuilder.AlterColumn<long>(
                name: "CategoryId",
                table: "Trips",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Categorys_CategoryId",
                table: "Trips",
                column: "CategoryId",
                principalTable: "Categorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Categorys_CategoryId",
                table: "Trips");

            migrationBuilder.AlterColumn<long>(
                name: "CategoryId",
                table: "Trips",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Categorys_CategoryId",
                table: "Trips",
                column: "CategoryId",
                principalTable: "Categorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
