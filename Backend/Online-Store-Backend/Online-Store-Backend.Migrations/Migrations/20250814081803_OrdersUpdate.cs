using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Store_Backend.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class OrdersUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_product_property_value_ProductID",
                schema: "public",
                table: "product_property_value");

            migrationBuilder.AddColumn<double>(
                name: "PriceWhenAdded",
                schema: "public",
                table: "order_product",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_user_Email",
                schema: "public",
                table: "user",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_Login",
                schema: "public",
                table: "user",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_PhoneNum",
                schema: "public",
                table: "user",
                column: "PhoneNum",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_property_value_ProductID_PropID",
                schema: "public",
                table: "product_property_value",
                columns: new[] { "ProductID", "PropID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_employee_Email",
                schema: "public",
                table: "employee",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_employee_Login",
                schema: "public",
                table: "employee",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_employee_PhoneNum",
                schema: "public",
                table: "employee",
                column: "PhoneNum",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_user_Email",
                schema: "public",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_Login",
                schema: "public",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_PhoneNum",
                schema: "public",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_product_property_value_ProductID_PropID",
                schema: "public",
                table: "product_property_value");

            migrationBuilder.DropIndex(
                name: "IX_employee_Email",
                schema: "public",
                table: "employee");

            migrationBuilder.DropIndex(
                name: "IX_employee_Login",
                schema: "public",
                table: "employee");

            migrationBuilder.DropIndex(
                name: "IX_employee_PhoneNum",
                schema: "public",
                table: "employee");

            migrationBuilder.DropColumn(
                name: "PriceWhenAdded",
                schema: "public",
                table: "order_product");

            migrationBuilder.CreateIndex(
                name: "IX_product_property_value_ProductID",
                schema: "public",
                table: "product_property_value",
                column: "ProductID");
        }
    }
}
