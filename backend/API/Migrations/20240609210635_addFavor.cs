using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class addFavor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FavorId",
                table: "Technologies",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Favors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Stages = table.Column<byte[]>(type: "smallint[]", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchieved = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Technologies_FavorId",
                table: "Technologies",
                column: "FavorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Technologies_Favors_FavorId",
                table: "Technologies",
                column: "FavorId",
                principalTable: "Favors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Technologies_Favors_FavorId",
                table: "Technologies");

            migrationBuilder.DropTable(
                name: "Favors");

            migrationBuilder.DropIndex(
                name: "IX_Technologies_FavorId",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "FavorId",
                table: "Technologies");
        }
    }
}
