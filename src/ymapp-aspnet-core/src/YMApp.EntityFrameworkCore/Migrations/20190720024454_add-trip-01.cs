using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YMApp.Migrations
{
    public partial class addtrip01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trip");

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    CategoryId = table.Column<long>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    PictureUrl = table.Column<string>(maxLength: 200, nullable: true),
                    Describe = table.Column<string>(maxLength: 500, nullable: true),
                    Content = table.Column<string>(type: "ntext", nullable: true),
                    State = table.Column<int>(nullable: false, defaultValue: 0),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_CategoryId",
                table: "Trips",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<long>(nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Describe = table.Column<string>(maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    PictureUrl = table.Column<string>(maxLength: 200, nullable: true),
                    State = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trip_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trip_CategoryId",
                table: "Trip",
                column: "CategoryId");
        }
    }
}
