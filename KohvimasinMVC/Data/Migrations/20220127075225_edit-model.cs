using Microsoft.EntityFrameworkCore.Migrations;

namespace KohvimasinMVC.Data.Migrations
{
    public partial class editmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Jookepakis",
                table: "Kohvimasin");

            migrationBuilder.DropColumn(
                name: "Topsepakis",
                table: "Kohvimasin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Jookepakis",
                table: "Kohvimasin",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Topsepakis",
                table: "Kohvimasin",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
