using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldImporters.Data.Migrations;

/// <inheritdoc />
public partial class Init : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder) { }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "CustomerCustomerDemo");

        migrationBuilder.DropTable(
            name: "EmployeeTerritories");

        migrationBuilder.DropTable(
            name: "Order Details");

        migrationBuilder.DropTable(
            name: "CustomerDemographics");

        migrationBuilder.DropTable(
            name: "Territories");

        migrationBuilder.DropTable(
            name: "Orders");

        migrationBuilder.DropTable(
            name: "Products");

        migrationBuilder.DropTable(
            name: "Region");

        migrationBuilder.DropTable(
            name: "Customers");

        migrationBuilder.DropTable(
            name: "Employees");

        migrationBuilder.DropTable(
            name: "Shippers");

        migrationBuilder.DropTable(
            name: "Categories");

        migrationBuilder.DropTable(
            name: "Suppliers");
    }
}
