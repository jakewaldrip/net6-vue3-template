using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sil_backend.Migrations
{
    public partial class TwitterHandle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TwitterHandle",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TwitterHandle",
                table: "Users");
        }
    }
}
