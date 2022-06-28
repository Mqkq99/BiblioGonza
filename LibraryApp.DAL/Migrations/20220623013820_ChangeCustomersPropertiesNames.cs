using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.DAL.Migrations
{
    public partial class ChangeCustomersPropertiesNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Customers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Customers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Direccion",
                table: "Customers",
                newName: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Customers",
                newName: "Telefono");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customers",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Customers",
                newName: "Direccion");
        }
    }
}
