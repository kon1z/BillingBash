using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kon.BillingBash.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePriceDecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "AppItem",
                type: "numeric(9,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "AppItem",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(9,2)");
        }
    }
}
