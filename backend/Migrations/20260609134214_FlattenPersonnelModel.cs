using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class FlattenPersonnelModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personnel_Tasks_MaintenanceTaskId",
                table: "Personnel");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnel_Tasks_Technician_CurrentTaskId",
                table: "Personnel");

            migrationBuilder.DropIndex(
                name: "IX_Personnel_MaintenanceTaskId",
                table: "Personnel");

            migrationBuilder.DropIndex(
                name: "IX_Personnel_Technician_CurrentTaskId",
                table: "Personnel");

            migrationBuilder.DropColumn(
                name: "MaintenanceTaskId",
                table: "Personnel");

            migrationBuilder.DropColumn(
                name: "Technician_CurrentTaskId",
                table: "Personnel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaintenanceTaskId",
                table: "Personnel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Technician_CurrentTaskId",
                table: "Personnel",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personnel_MaintenanceTaskId",
                table: "Personnel",
                column: "MaintenanceTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnel_Technician_CurrentTaskId",
                table: "Personnel",
                column: "Technician_CurrentTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personnel_Tasks_MaintenanceTaskId",
                table: "Personnel",
                column: "MaintenanceTaskId",
                principalTable: "Tasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personnel_Tasks_Technician_CurrentTaskId",
                table: "Personnel",
                column: "Technician_CurrentTaskId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }
    }
}
