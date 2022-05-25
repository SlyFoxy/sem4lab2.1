using Microsoft.EntityFrameworkCore.Migrations;

namespace sem4lab2._1.Migrations
{
    public partial class ChangeAccounts1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "AccountOwnerId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountOwnerId",
                table: "Accounts",
                column: "AccountOwnerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Clients_AccountOwnerId",
                table: "Accounts",
                column: "AccountOwnerId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Clients_AccountOwnerId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccountOwnerId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountOwnerId",
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
    }
}
