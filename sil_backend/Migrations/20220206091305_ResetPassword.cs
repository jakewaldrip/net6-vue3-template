using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sil_backend.Migrations
{
    public partial class ResetPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResetPassword",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Token = table.Column<string>(type: "TEXT", nullable: false),
                    UserEmail = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResetPassword", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResetPassword");
        }
    }
}
