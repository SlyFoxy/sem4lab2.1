using Microsoft.EntityFrameworkCore.Migrations;

namespace sem4lab2._1.Migrations
{
    public partial class ChangeAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Clients_ClientId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_ClientId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AccountId",
                table: "Clients",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Accounts_AccountId",
                table: "Clients",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Accounts_AccountId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_AccountId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ClientId",
                table: "Accounts",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Clients_ClientId",
                table: "Accounts",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
