using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspnetRun.Infrastructure.Migrations
{
    public partial class updateReservationsTableAndCourtTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "SessionTime",
                table: "Courts",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "SessionTime",
                table: "Courts");
        }
    }
}
