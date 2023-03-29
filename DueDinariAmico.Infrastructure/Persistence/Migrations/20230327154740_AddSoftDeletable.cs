using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DueDinariAmico.Infrastructure.Migrations
{
    public partial class AddSoftDeletable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelted",
                table: "ExchangeRateLists");

            migrationBuilder.AlterColumn<string>(
                name: "Pro",
                table: "ExchangeRateLists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Kup",
                table: "ExchangeRateLists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ExchangeRateLists",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRateLists_Id",
                table: "ExchangeRateLists",
                column: "Id",
                unique: true,
                filter: "[IsDeleted] != 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExchangeRateLists_Id",
                table: "ExchangeRateLists");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ExchangeRateLists");

            migrationBuilder.AlterColumn<string>(
                name: "Pro",
                table: "ExchangeRateLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Kup",
                table: "ExchangeRateLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelted",
                table: "ExchangeRateLists",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
