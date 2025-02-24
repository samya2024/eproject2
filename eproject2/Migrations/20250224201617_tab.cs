using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eproject2.Migrations
{
    /// <inheritdoc />
    public partial class tab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DashboardmodelId",
                table: "UserSubscriptions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DashboardmodelId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DashboardmodelId",
                table: "UserProfiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DashboardmodelId",
                table: "Reports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DashboardmodelId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DashboardmodelId",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DashboardmodelId",
                table: "Listings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DashboardmodelId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "dashboard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalUsers = table.Column<int>(type: "int", nullable: false),
                    TotalListings = table.Column<int>(type: "int", nullable: false),
                    ActiveSubscriptions = table.Column<int>(type: "int", nullable: false),
                    TotalPayments = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dashboard", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSubscriptions_DashboardmodelId",
                table: "UserSubscriptions",
                column: "DashboardmodelId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DashboardmodelId",
                table: "Users",
                column: "DashboardmodelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_DashboardmodelId",
                table: "UserProfiles",
                column: "DashboardmodelId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_DashboardmodelId",
                table: "Reports",
                column: "DashboardmodelId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_DashboardmodelId",
                table: "Payments",
                column: "DashboardmodelId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_DashboardmodelId",
                table: "Locations",
                column: "DashboardmodelId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_DashboardmodelId",
                table: "Listings",
                column: "DashboardmodelId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_DashboardmodelId",
                table: "Categories",
                column: "DashboardmodelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_dashboard_DashboardmodelId",
                table: "Categories",
                column: "DashboardmodelId",
                principalTable: "dashboard",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_dashboard_DashboardmodelId",
                table: "Listings",
                column: "DashboardmodelId",
                principalTable: "dashboard",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_dashboard_DashboardmodelId",
                table: "Locations",
                column: "DashboardmodelId",
                principalTable: "dashboard",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_dashboard_DashboardmodelId",
                table: "Payments",
                column: "DashboardmodelId",
                principalTable: "dashboard",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_dashboard_DashboardmodelId",
                table: "Reports",
                column: "DashboardmodelId",
                principalTable: "dashboard",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_dashboard_DashboardmodelId",
                table: "UserProfiles",
                column: "DashboardmodelId",
                principalTable: "dashboard",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_dashboard_DashboardmodelId",
                table: "Users",
                column: "DashboardmodelId",
                principalTable: "dashboard",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSubscriptions_dashboard_DashboardmodelId",
                table: "UserSubscriptions",
                column: "DashboardmodelId",
                principalTable: "dashboard",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_dashboard_DashboardmodelId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_dashboard_DashboardmodelId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_dashboard_DashboardmodelId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_dashboard_DashboardmodelId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_dashboard_DashboardmodelId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_dashboard_DashboardmodelId",
                table: "UserProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_dashboard_DashboardmodelId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSubscriptions_dashboard_DashboardmodelId",
                table: "UserSubscriptions");

            migrationBuilder.DropTable(
                name: "dashboard");

            migrationBuilder.DropIndex(
                name: "IX_UserSubscriptions_DashboardmodelId",
                table: "UserSubscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Users_DashboardmodelId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_DashboardmodelId",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_Reports_DashboardmodelId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Payments_DashboardmodelId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Locations_DashboardmodelId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Listings_DashboardmodelId",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Categories_DashboardmodelId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DashboardmodelId",
                table: "UserSubscriptions");

            migrationBuilder.DropColumn(
                name: "DashboardmodelId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DashboardmodelId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "DashboardmodelId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "DashboardmodelId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "DashboardmodelId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "DashboardmodelId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "DashboardmodelId",
                table: "Categories");
        }
    }
}
