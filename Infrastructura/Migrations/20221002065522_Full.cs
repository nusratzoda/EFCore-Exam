using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructura.Migrations
{
    /// <inheritdoc />
    public partial class Full : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Chalanges_ChalangeId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Groups_GroupId",
                table: "Participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Groupes");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_ChalangeId",
                table: "Groupes",
                newName: "IX_Groupes_ChalangeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groupes",
                table: "Groupes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Groupes_Chalanges_ChalangeId",
                table: "Groupes",
                column: "ChalangeId",
                principalTable: "Chalanges",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Groupes_GroupId",
                table: "Participants",
                column: "GroupId",
                principalTable: "Groupes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groupes_Chalanges_ChalangeId",
                table: "Groupes");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Groupes_GroupId",
                table: "Participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groupes",
                table: "Groupes");

            migrationBuilder.RenameTable(
                name: "Groupes",
                newName: "Groups");

            migrationBuilder.RenameIndex(
                name: "IX_Groupes_ChalangeId",
                table: "Groups",
                newName: "IX_Groups_ChalangeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Chalanges_ChalangeId",
                table: "Groups",
                column: "ChalangeId",
                principalTable: "Chalanges",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Groups_GroupId",
                table: "Participants",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
