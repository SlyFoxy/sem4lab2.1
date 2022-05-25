using Microsoft.EntityFrameworkCore.Migrations;

namespace sem4lab2._1.Migrations
{
    public partial class MovedField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditLimit",
                table: "Accounts");

            migrationBuilder.AddColumn<float>(
                name: "CreditLimit",
                table: "CreditCards",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditLimit",
                table: "CreditCards");

            migrationBuilder.AddColumn<float>(
                name: "CreditLimit",
                table: "Accounts",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
