using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaPlaceSalesAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDBTBL_Pizza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pizzas_pizza_type_pizza_type_id",
                table: "pizzas");

            migrationBuilder.DropIndex(
                name: "IX_pizzas_pizza_type_id",
                table: "pizzas");

            migrationBuilder.DropColumn(
                name: "pizza_type_id",
                table: "pizzas");

            migrationBuilder.DropColumn(
                name: "type_id",
                table: "pizzas");

            migrationBuilder.AddColumn<string>(
                name: "pizza_type_id1",
                table: "pizzas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_pizzas_pizza_type_id1",
                table: "pizzas",
                column: "pizza_type_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_pizzas_pizza_type_pizza_type_id1",
                table: "pizzas",
                column: "pizza_type_id1",
                principalTable: "pizza_type",
                principalColumn: "pizza_type_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pizzas_pizza_type_pizza_type_id1",
                table: "pizzas");

            migrationBuilder.DropIndex(
                name: "IX_pizzas_pizza_type_id1",
                table: "pizzas");

            migrationBuilder.DropColumn(
                name: "pizza_type_id1",
                table: "pizzas");

            migrationBuilder.AddColumn<string>(
                name: "pizza_type_id",
                table: "pizzas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "type_id",
                table: "pizzas",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_pizzas_pizza_type_id",
                table: "pizzas",
                column: "pizza_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_pizzas_pizza_type_pizza_type_id",
                table: "pizzas",
                column: "pizza_type_id",
                principalTable: "pizza_type",
                principalColumn: "pizza_type_id");
        }
    }
}
