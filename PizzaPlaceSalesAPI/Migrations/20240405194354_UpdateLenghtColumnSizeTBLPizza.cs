using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaPlaceSalesAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLenghtColumnSizeTBLPizza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "size",
                table: "pizzas",
                type: "char(5)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "size",
                table: "pizzas",
                type: "char(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(5)");
        }
    }
}
