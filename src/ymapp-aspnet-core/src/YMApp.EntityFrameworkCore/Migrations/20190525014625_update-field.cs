using Microsoft.EntityFrameworkCore.Migrations;

namespace YMApp.Migrations
{
    public partial class updatefield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldGrade",
                table: "ProductAttributes");

            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "ProductFields",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "ProductAttributes",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "ProductFields");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProductAttributes");

            migrationBuilder.AddColumn<int>(
                name: "FieldGrade",
                table: "ProductAttributes",
                nullable: false,
                defaultValue: 0);
        }
    }
}
