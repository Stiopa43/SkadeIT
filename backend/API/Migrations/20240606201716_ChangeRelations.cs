using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTechnology_Services_ServiceId",
                table: "ServiceTechnology");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTechnology_Technologies_TechnologyId",
                table: "ServiceTechnology");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceTechnology",
                table: "ServiceTechnology");

            migrationBuilder.RenameTable(
                name: "ServiceTechnology",
                newName: "ServiceTechnologies");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceTechnology_TechnologyId",
                table: "ServiceTechnologies",
                newName: "IX_ServiceTechnologies_TechnologyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceTechnologies",
                table: "ServiceTechnologies",
                columns: new[] { "ServiceId", "TechnologyId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTechnologies_Services_ServiceId",
                table: "ServiceTechnologies",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTechnologies_Technologies_TechnologyId",
                table: "ServiceTechnologies",
                column: "TechnologyId",
                principalTable: "Technologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTechnologies_Services_ServiceId",
                table: "ServiceTechnologies");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTechnologies_Technologies_TechnologyId",
                table: "ServiceTechnologies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceTechnologies",
                table: "ServiceTechnologies");

            migrationBuilder.RenameTable(
                name: "ServiceTechnologies",
                newName: "ServiceTechnology");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceTechnologies_TechnologyId",
                table: "ServiceTechnology",
                newName: "IX_ServiceTechnology_TechnologyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceTechnology",
                table: "ServiceTechnology",
                columns: new[] { "ServiceId", "TechnologyId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTechnology_Services_ServiceId",
                table: "ServiceTechnology",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTechnology_Technologies_TechnologyId",
                table: "ServiceTechnology",
                column: "TechnologyId",
                principalTable: "Technologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
