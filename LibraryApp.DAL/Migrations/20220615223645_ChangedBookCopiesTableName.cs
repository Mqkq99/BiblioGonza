using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.DAL.Migrations
{
    public partial class ChangedBookCopiesTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksCopy_Books_BookId",
                table: "BooksCopy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BooksCopy",
                table: "BooksCopy");

            migrationBuilder.RenameTable(
                name: "BooksCopy",
                newName: "BooksCopies");

            migrationBuilder.RenameIndex(
                name: "IX_BooksCopy_BookId",
                table: "BooksCopies",
                newName: "IX_BooksCopies_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BooksCopies",
                table: "BooksCopies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksCopies_Books_BookId",
                table: "BooksCopies",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksCopies_Books_BookId",
                table: "BooksCopies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BooksCopies",
                table: "BooksCopies");

            migrationBuilder.RenameTable(
                name: "BooksCopies",
                newName: "BooksCopy");

            migrationBuilder.RenameIndex(
                name: "IX_BooksCopies_BookId",
                table: "BooksCopy",
                newName: "IX_BooksCopy_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BooksCopy",
                table: "BooksCopy",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksCopy_Books_BookId",
                table: "BooksCopy",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
