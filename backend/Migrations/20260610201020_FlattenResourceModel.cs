using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class FlattenResourceModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResourceRequirements_ResourceBuffer_BufferId",
                table: "ResourceRequirements");

            migrationBuilder.DropTable(
                name: "ResourceBuffer");

            migrationBuilder.DropIndex(
                name: "IX_ResourceRequirements_BufferId",
                table: "ResourceRequirements");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Resources");

            migrationBuilder.RenameColumn(
                name: "BufferId",
                table: "ResourceRequirements",
                newName: "Buffer_OptimalReqAmount");

            migrationBuilder.AddColumn<int>(
                name: "Buffer_MaxReqAmount",
                table: "ResourceRequirements",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Buffer_MinReqAmount",
                table: "ResourceRequirements",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Buffer_MaxReqAmount",
                table: "ResourceRequirements");

            migrationBuilder.DropColumn(
                name: "Buffer_MinReqAmount",
                table: "ResourceRequirements");

            migrationBuilder.RenameColumn(
                name: "Buffer_OptimalReqAmount",
                table: "ResourceRequirements",
                newName: "BufferId");

            migrationBuilder.AddColumn<int>(
                name: "Unit",
                table: "Resources",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ResourceBuffer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaxReqAmount = table.Column<int>(type: "integer", nullable: false),
                    MinReqAmount = table.Column<int>(type: "integer", nullable: false),
                    OptimalReqAmount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceBuffer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceRequirements_BufferId",
                table: "ResourceRequirements",
                column: "BufferId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceRequirements_ResourceBuffer_BufferId",
                table: "ResourceRequirements",
                column: "BufferId",
                principalTable: "ResourceBuffer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
