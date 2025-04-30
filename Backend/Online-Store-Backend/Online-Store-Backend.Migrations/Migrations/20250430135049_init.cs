using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Online_Store_Backend.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "category",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "GEN_RANDOM_UUID()"),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PhoneNum = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<bool>(type: "boolean", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Login = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "permission",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permission", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "GEN_RANDOM_UUID()"),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PhoneNum = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<bool>(type: "boolean", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Login = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PasswordHash = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "category_prop",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryID = table.Column<int>(type: "integer", nullable: false),
                    PropName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ValueType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category_prop", x => x.ID);
                    table.ForeignKey(
                        name: "FK_category_prop_category_CategoryID",
                        column: x => x.CategoryID,
                        principalSchema: "public",
                        principalTable: "category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "GEN_RANDOM_UUID()"),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CategoryID = table.Column<int>(type: "integer", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_product_category_CategoryID",
                        column: x => x.CategoryID,
                        principalSchema: "public",
                        principalTable: "category",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "employee_permission",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeID = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissionID = table.Column<int>(type: "integer", nullable: false),
                    DateOfAdding = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_permission", x => x.ID);
                    table.ForeignKey(
                        name: "FK_employee_permission_employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalSchema: "public",
                        principalTable: "employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employee_permission_permission_PermissionID",
                        column: x => x.PermissionID,
                        principalSchema: "public",
                        principalTable: "permission",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "GEN_RANDOM_UUID()"),
                    TotalPrice = table.Column<double>(type: "double precision", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.ID);
                    table.ForeignKey(
                        name: "FK_order_user_UserID",
                        column: x => x.UserID,
                        principalSchema: "public",
                        principalTable: "user",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_image",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "GEN_RANDOM_UUID()"),
                    ImageAddress = table.Column<string>(type: "text", nullable: true),
                    ProductID = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_image", x => x.ID);
                    table.ForeignKey(
                        name: "FK_product_image_product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "public",
                        principalTable: "product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_property_value",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductID = table.Column<Guid>(type: "uuid", nullable: false),
                    PropID = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DateOfAdding = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_property_value", x => x.ID);
                    table.ForeignKey(
                        name: "FK_product_property_value_category_prop_PropID",
                        column: x => x.PropID,
                        principalSchema: "public",
                        principalTable: "category_prop",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_property_value_product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "public",
                        principalTable: "product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_product",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderID = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductID = table.Column<Guid>(type: "uuid", nullable: false),
                    DateOfAdding = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_order_product_order_OrderID",
                        column: x => x.OrderID,
                        principalSchema: "public",
                        principalTable: "order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_product_product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "public",
                        principalTable: "product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_category_prop_CategoryID",
                schema: "public",
                table: "category_prop",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_employee_permission_EmployeeID",
                schema: "public",
                table: "employee_permission",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_employee_permission_PermissionID",
                schema: "public",
                table: "employee_permission",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_order_UserID",
                schema: "public",
                table: "order",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_order_product_OrderID",
                schema: "public",
                table: "order_product",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_order_product_ProductID",
                schema: "public",
                table: "order_product",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_product_CategoryID",
                schema: "public",
                table: "product",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_product_image_ProductID",
                schema: "public",
                table: "product_image",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_product_property_value_ProductID",
                schema: "public",
                table: "product_property_value",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_product_property_value_PropID",
                schema: "public",
                table: "product_property_value",
                column: "PropID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee_permission",
                schema: "public");

            migrationBuilder.DropTable(
                name: "order_product",
                schema: "public");

            migrationBuilder.DropTable(
                name: "product_image",
                schema: "public");

            migrationBuilder.DropTable(
                name: "product_property_value",
                schema: "public");

            migrationBuilder.DropTable(
                name: "employee",
                schema: "public");

            migrationBuilder.DropTable(
                name: "permission",
                schema: "public");

            migrationBuilder.DropTable(
                name: "order",
                schema: "public");

            migrationBuilder.DropTable(
                name: "category_prop",
                schema: "public");

            migrationBuilder.DropTable(
                name: "product",
                schema: "public");

            migrationBuilder.DropTable(
                name: "user",
                schema: "public");

            migrationBuilder.DropTable(
                name: "category",
                schema: "public");
        }
    }
}
