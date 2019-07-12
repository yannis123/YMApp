using Microsoft.EntityFrameworkCore.Migrations;

namespace YMApp.Migrations
{
    public partial class upodatecategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Categorys_CategoryId",
                table: "Trips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trips",
                table: "Trips");

            migrationBuilder.RenameTable(
                name: "Trips",
                newName: "Trip");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_CategoryId",
                table: "Trip",
                newName: "IX_Trip_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trip",
                table: "Trip",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Categorys_CategoryId",
                table: "Trip",
                column: "CategoryId",
                principalTable: "Categorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Categorys_CategoryId",
                table: "Trip");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trip",
                table: "Trip");

            migrationBuilder.RenameTable(
                name: "Trip",
                newName: "Trips");

            migrationBuilder.RenameIndex(
                name: "IX_Trip_CategoryId",
                table: "Trips",
                newName: "IX_Trips_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trips",
                table: "Trips",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Categorys_CategoryId",
                table: "Trips",
                column: "CategoryId",
                principalTable: "Categorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
