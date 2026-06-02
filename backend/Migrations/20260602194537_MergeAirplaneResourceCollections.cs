using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class MergeAirplaneResourceCollections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Airplanes_Ammunition_AirplaneId",
                table: "Resources");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Airplanes_Battery_AirplaneId",
                table: "Resources");

            migrationBuilder.DropIndex(
                name: "IX_Resources_Ammunition_AirplaneId",
                table: "Resources");

            migrationBuilder.DropIndex(
                name: "IX_Resources_Battery_AirplaneId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "Ammunition_AirplaneId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "Battery_AirplaneId",
                table: "Resources");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ammunition_AirplaneId",
                table: "Resources",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Battery_AirplaneId",
                table: "Resources",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resources_Ammunition_AirplaneId",
                table: "Resources",
                column: "Ammunition_AirplaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_Battery_AirplaneId",
                table: "Resources",
                column: "Battery_AirplaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Airplanes_Ammunition_AirplaneId",
                table: "Resources",
                column: "Ammunition_AirplaneId",
                principalTable: "Airplanes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Airplanes_Battery_AirplaneId",
                table: "Resources",
                column: "Battery_AirplaneId",
                principalTable: "Airplanes",
                principalColumn: "Id");
        }
    }
}
