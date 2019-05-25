using Microsoft.EntityFrameworkCore.Migrations;

namespace YMApp.Migrations
{
    public partial class updateproduct001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "ProductAttributes",
                newName: "ParentId");

            migrationBuilder.AddColumn<long>(
                name: "FieldId",
                table: "ProductAttributes",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldId",
                table: "ProductAttributes");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "ProductAttributes",
                newName: "CategoryId");
        }
    }
}
