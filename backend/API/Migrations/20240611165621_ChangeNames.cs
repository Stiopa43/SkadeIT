using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTechnologies_Services_ServiceId",
                table: "ServiceTechnologies");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicesPhotos_Services_ServiceId",
                table: "ServicesPhotos");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "ServicesPhotos",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ServicesPhotos_ServiceId",
                table: "ServicesPhotos",
                newName: "IX_ServicesPhotos_ProjectId");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "ServiceTechnologies",
                newName: "ProjectId");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Stage = table.Column<byte>(type: "smallint", nullable: false),
                    StageDescription = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchieved = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTechnologies_Projects_ProjectId",
                table: "ServiceTechnologies",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesPhotos_Projects_ProjectId",
                table: "ServicesPhotos",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTechnologies_Projects_ProjectId",
                table: "ServiceTechnologies");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicesPhotos_Projects_ProjectId",
                table: "ServicesPhotos");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "ServicesPhotos",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServicesPhotos_ProjectId",
                table: "ServicesPhotos",
                newName: "IX_ServicesPhotos_ServiceId");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "ServiceTechnologies",
                newName: "ServiceId");

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsArchieved = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastModifiedDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Stage = table.Column<byte>(type: "smallint", nullable: false),
                    StageDescription = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTechnologies_Services_ServiceId",
                table: "ServiceTechnologies",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesPhotos_Services_ServiceId",
                table: "ServicesPhotos",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
