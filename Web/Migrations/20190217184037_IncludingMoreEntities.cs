using Microsoft.EntityFrameworkCore.Migrations;

namespace BancoDeSangre.Migrations
{
    public partial class IncludingMoreEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Users_UserId",
                table: "Campaigns");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Campaigns",
                newName: "ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Campaigns_UserId",
                table: "Campaigns",
                newName: "IX_Campaigns_ManagerId");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Campaigns",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Campaigns",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Users_ManagerId",
                table: "Campaigns",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Users_ManagerId",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Campaigns");

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "Campaigns",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Campaigns_ManagerId",
                table: "Campaigns",
                newName: "IX_Campaigns_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Users_UserId",
                table: "Campaigns",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
