using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dashboard.Migrations
{
    /// <inheritdoc />
    public partial class MySeventhMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ProductDeatails",
                newName: "AutherName");

            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "ProductDeatails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "ProductDeatails");

            migrationBuilder.RenameColumn(
                name: "AutherName",
                table: "ProductDeatails",
                newName: "Description");
        }
    }
}
