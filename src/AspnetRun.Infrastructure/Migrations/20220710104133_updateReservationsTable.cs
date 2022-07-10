using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspnetRun.Infrastructure.Migrations
{
    public partial class updateReservationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Reservations",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Reservations",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Reservations");
        }
    }
}
