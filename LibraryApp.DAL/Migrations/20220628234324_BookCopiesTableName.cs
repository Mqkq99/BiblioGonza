using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.DAL.Migrations
{
    public partial class BookCopiesTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksCopies_Books_BookId",
                table: "BooksCopies");

            migrationBuilder.DropForeignKey(
                name: "FK_Withdrawals_BooksCopies_BookCopyId",
                table: "Withdrawals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BooksCopies",
                table: "BooksCopies");

            migrationBuilder.RenameTable(
                name: "BooksCopies",
                newName: "BookCopies");

            migrationBuilder.RenameIndex(
                name: "IX_BooksCopies_BookId",
                table: "BookCopies",
                newName: "IX_BookCopies_BookId");

            migrationBuilder.AlterColumn<string>(
                name: "BookId",
                table: "BookCopies",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCopies",
                table: "BookCopies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCopies_Books_BookId",
                table: "BookCopies",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Withdrawals_BookCopies_BookCopyId",
                table: "Withdrawals",
                column: "BookCopyId",
                principalTable: "BookCopies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCopies_Books_BookId",
                table: "BookCopies");

            migrationBuilder.DropForeignKey(
                name: "FK_Withdrawals_BookCopies_BookCopyId",
                table: "Withdrawals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCopies",
                table: "BookCopies");

            migrationBuilder.RenameTable(
                name: "BookCopies",
                newName: "BooksCopies");

            migrationBuilder.RenameIndex(
                name: "IX_BookCopies_BookId",
                table: "BooksCopies",
                newName: "IX_BooksCopies_BookId");

            migrationBuilder.AlterColumn<string>(
                name: "BookId",
                table: "BooksCopies",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Withdrawals_BooksCopies_BookCopyId",
                table: "Withdrawals",
                column: "BookCopyId",
                principalTable: "BooksCopies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
