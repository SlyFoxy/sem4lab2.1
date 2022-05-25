using Microsoft.EntityFrameworkCore.Migrations;

namespace sem4lab2._1.Migrations
{
    public partial class loginpassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Admins");
        }
    }
}
