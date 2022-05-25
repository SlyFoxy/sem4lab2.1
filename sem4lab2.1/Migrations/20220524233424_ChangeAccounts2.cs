using Microsoft.EntityFrameworkCore.Migrations;

namespace sem4lab2._1.Migrations
{
    public partial class ChangeAccounts2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Clients_AccountOwnerId",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "AccountOwnerId",
                table: "Accounts",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_AccountOwnerId",
                table: "Accounts",
                newName: "IX_Accounts_ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Clients_ClientId",
                table: "Accounts",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Clients_ClientId",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Accounts",
                newName: "AccountOwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_ClientId",
                table: "Accounts",
                newName: "IX_Accounts_AccountOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Clients_AccountOwnerId",
                table: "Accounts",
                column: "AccountOwnerId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
