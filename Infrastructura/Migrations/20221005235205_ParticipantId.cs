using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructura.Migrations
{
    /// <inheritdoc />
    public partial class ParticipantId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Locations_LocationId",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_Participants_LocationId",
                table: "Participants");

            migrationBuilder.AddColumn<int>(
                name: "LoctionId",
                table: "Participants",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Participants_LoctionId",
                table: "Participants",
                column: "LoctionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Locations_LoctionId",
                table: "Participants",
                column: "LoctionId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Locations_LoctionId",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_Participants_LoctionId",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "LoctionId",
                table: "Participants");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_LocationId",
                table: "Participants",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Locations_LocationId",
                table: "Participants",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
