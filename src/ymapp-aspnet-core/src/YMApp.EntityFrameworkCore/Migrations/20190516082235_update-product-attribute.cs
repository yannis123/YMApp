using Microsoft.EntityFrameworkCore.Migrations;

namespace YMApp.Migrations
{
    public partial class updateproductattribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FieldGrade",
                table: "ProductFields",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FieldGrade",
                table: "ProductAttributes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldGrade",
                table: "ProductFields");

            migrationBuilder.DropColumn(
                name: "FieldGrade",
                table: "ProductAttributes");
        }
    }
}
