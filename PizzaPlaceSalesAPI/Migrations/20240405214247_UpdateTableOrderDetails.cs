using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaPlaceSalesAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableOrderDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_details_pizzas_pizza_id1",
                table: "order_details");

            migrationBuilder.DropIndex(
                name: "IX_order_details_pizza_id1",
                table: "order_details");

            migrationBuilder.DropColumn(
                name: "pizza_id1",
                table: "order_details");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pizza_id1",
                table: "order_details",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_order_details_pizza_id1",
                table: "order_details",
                column: "pizza_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_order_details_pizzas_pizza_id1",
                table: "order_details",
                column: "pizza_id1",
                principalTable: "pizzas",
                principalColumn: "pizza_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
