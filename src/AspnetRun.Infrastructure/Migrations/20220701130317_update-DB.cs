using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspnetRun.Infrastructure.Migrations
{
    public partial class updateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHour_Courts_CourtId",
                table: "WorkingHour");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkingHour",
                table: "WorkingHour");

            migrationBuilder.RenameTable(
                name: "WorkingHour",
                newName: "WorkingHours");

            migrationBuilder.RenameIndex(
                name: "IX_WorkingHour_CourtId",
                table: "WorkingHours",
                newName: "IX_WorkingHours_CourtId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkingHours",
                table: "WorkingHours",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_Courts_CourtId",
                table: "WorkingHours",
                column: "CourtId",
                principalTable: "Courts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_Courts_CourtId",
                table: "WorkingHours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkingHours",
                table: "WorkingHours");

            migrationBuilder.RenameTable(
                name: "WorkingHours",
                newName: "WorkingHour");

            migrationBuilder.RenameIndex(
                name: "IX_WorkingHours_CourtId",
                table: "WorkingHour",
                newName: "IX_WorkingHour_CourtId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkingHour",
                table: "WorkingHour",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHour_Courts_CourtId",
                table: "WorkingHour",
                column: "CourtId",
                principalTable: "Courts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
