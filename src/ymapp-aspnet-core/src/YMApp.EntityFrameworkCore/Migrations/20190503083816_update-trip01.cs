using Microsoft.EntityFrameworkCore.Migrations;

namespace YMApp.Migrations
{
    public partial class updatetrip01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Trips",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Trips",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);
        }
    }
}
