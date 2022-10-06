using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructura.Migrations
{
    /// <inheritdoc />
    public partial class Challange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groupes_Chalanges_ChalangeId",
                table: "Groupes");

            migrationBuilder.DropIndex(
                name: "IX_Groupes_ChalangeId",
                table: "Groupes");

            migrationBuilder.DropColumn(
                name: "ChalangeId",
                table: "Groupes");

            migrationBuilder.CreateIndex(
                name: "IX_Groupes_ChallangeId",
                table: "Groupes",
                column: "ChallangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groupes_Chalanges_ChallangeId",
                table: "Groupes",
                column: "ChallangeId",
                principalTable: "Chalanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groupes_Chalanges_ChallangeId",
                table: "Groupes");

            migrationBuilder.DropIndex(
                name: "IX_Groupes_ChallangeId",
                table: "Groupes");

            migrationBuilder.AddColumn<int>(
                name: "ChalangeId",
                table: "Groupes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Groupes_ChalangeId",
                table: "Groupes",
                column: "ChalangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groupes_Chalanges_ChalangeId",
                table: "Groupes",
                column: "ChalangeId",
                principalTable: "Chalanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
