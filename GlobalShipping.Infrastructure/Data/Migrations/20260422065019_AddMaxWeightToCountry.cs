using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalShipping.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMaxWeightToCountry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MaxWeight",
                table: "Countries",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "MaxWeight",
                value: 50.0m);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2,
                column: "MaxWeight",
                value: 100.0m);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3,
                column: "MaxWeight",
                value: 70.0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxWeight",
                table: "Countries");
        }
    }
}
