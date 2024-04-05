using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaPlaceSalesAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pizza_type_pizzas_PizzasModelpizza_id",
                table: "pizza_type");

            migrationBuilder.DropIndex(
                name: "IX_pizza_type_PizzasModelpizza_id",
                table: "pizza_type");

            migrationBuilder.DropColumn(
                name: "PizzasModelpizza_id",
                table: "pizza_type");

            migrationBuilder.AddColumn<string>(
                name: "pizza_type_id",
                table: "pizzas",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pizza_type_id",
                table: "pizzas");

            migrationBuilder.AddColumn<string>(
                name: "PizzasModelpizza_id",
                table: "pizza_type",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_pizza_type_PizzasModelpizza_id",
                table: "pizza_type",
                column: "PizzasModelpizza_id");

            migrationBuilder.AddForeignKey(
                name: "FK_pizza_type_pizzas_PizzasModelpizza_id",
                table: "pizza_type",
                column: "PizzasModelpizza_id",
                principalTable: "pizzas",
                principalColumn: "pizza_id");
        }
    }
}
