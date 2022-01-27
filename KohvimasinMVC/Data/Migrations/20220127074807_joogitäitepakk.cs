using Microsoft.EntityFrameworkCore.Migrations;

namespace KohvimasinMVC.Data.Migrations
{
    public partial class joogitäitepakk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Jookepakis",
                table: "Kohvimasin",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Jookepakis",
                table: "Kohvimasin");
        }
    }
}
