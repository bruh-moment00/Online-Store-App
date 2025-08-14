using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Store_Backend.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class TotalPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                schema: "public",
                table: "order");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                schema: "public",
                table: "order",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
