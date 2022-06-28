using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.DAL.Migrations
{
    public partial class BookCopyAndEntityBaseChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Disabled",
                table: "Withdrawals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Disabled",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Disabled",
                table: "BooksCopies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Edition",
                table: "BooksCopies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BooksCopies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Disabled",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disabled",
                table: "Withdrawals");

            migrationBuilder.DropColumn(
                name: "Disabled",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Disabled",
                table: "BooksCopies");

            migrationBuilder.DropColumn(
                name: "Edition",
                table: "BooksCopies");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BooksCopies");

            migrationBuilder.DropColumn(
                name: "Disabled",
                table: "Books");
        }
    }
}
