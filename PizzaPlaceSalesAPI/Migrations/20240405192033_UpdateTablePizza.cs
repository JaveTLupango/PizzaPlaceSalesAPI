using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaPlaceSalesAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTablePizza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_details_pizzas_pizza_idid",
                table: "order_details");

            migrationBuilder.DropForeignKey(
                name: "FK_pizzas_pizza_type_pizza_type_id1",
                table: "pizzas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pizzas",
                table: "pizzas");

            migrationBuilder.DropIndex(
                name: "IX_order_details_pizza_idid",
                table: "order_details");

            migrationBuilder.DropColumn(
                name: "id",
                table: "pizzas");

            migrationBuilder.DropColumn(
                name: "pizza_idid",
                table: "order_details");

            migrationBuilder.AlterColumn<string>(
                name: "pizza_type_id1",
                table: "pizzas",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "pizza_type_id",
                table: "pizzas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "pizza_id1",
                table: "order_details",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pizzas",
                table: "pizzas",
                column: "pizza_id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_pizzas_pizza_type_pizza_type_id1",
                table: "pizzas",
                column: "pizza_type_id1",
                principalTable: "pizza_type",
                principalColumn: "pizza_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_details_pizzas_pizza_id1",
                table: "order_details");

            migrationBuilder.DropForeignKey(
                name: "FK_pizzas_pizza_type_pizza_type_id1",
                table: "pizzas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pizzas",
                table: "pizzas");

            migrationBuilder.DropIndex(
                name: "IX_order_details_pizza_id1",
                table: "order_details");

            migrationBuilder.DropColumn(
                name: "pizza_type_id",
                table: "pizzas");

            migrationBuilder.DropColumn(
                name: "pizza_id1",
                table: "order_details");

            migrationBuilder.AlterColumn<string>(
                name: "pizza_type_id1",
                table: "pizzas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "pizzas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "pizza_idid",
                table: "order_details",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_pizzas",
                table: "pizzas",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_order_details_pizza_idid",
                table: "order_details",
                column: "pizza_idid");

            migrationBuilder.AddForeignKey(
                name: "FK_order_details_pizzas_pizza_idid",
                table: "order_details",
                column: "pizza_idid",
                principalTable: "pizzas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pizzas_pizza_type_pizza_type_id1",
                table: "pizzas",
                column: "pizza_type_id1",
                principalTable: "pizza_type",
                principalColumn: "pizza_type_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
