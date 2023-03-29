using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DueDinariAmico.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExchangeRateLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRateLists", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangeRateLists");
        }
    }
}
