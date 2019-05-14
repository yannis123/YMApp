using Microsoft.EntityFrameworkCore.Migrations;

namespace YMApp.Migrations
{
    public partial class updatecategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Categorys");

            migrationBuilder.AlterColumn<long>(
                name: "ParentId",
                table: "Categorys",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ParentId",
                table: "Categorys",
                nullable: false,
                oldClrType: typeof(long),
                oldDefaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Categorys",
                nullable: false,
                defaultValue: 0);
        }
    }
}
