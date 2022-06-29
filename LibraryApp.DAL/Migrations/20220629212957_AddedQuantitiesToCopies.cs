using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.DAL.Migrations
{
    public partial class AddedQuantitiesToCopies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "BookCopies",
                newName: "TotalQuantity");

            migrationBuilder.AddColumn<int>(
                name: "AvailableQuantity",
                table: "BookCopies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableQuantity",
                table: "BookCopies");

            migrationBuilder.RenameColumn(
                name: "TotalQuantity",
                table: "BookCopies",
                newName: "Quantity");
        }
    }
}
