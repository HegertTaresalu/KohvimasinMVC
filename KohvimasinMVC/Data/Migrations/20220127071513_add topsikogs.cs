using Microsoft.EntityFrameworkCore.Migrations;

namespace KohvimasinMVC.Data.Migrations
{
    public partial class addtopsikogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Topsikogus",
                table: "Kohvimasin",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Topsikogus",
                table: "Kohvimasin");
        }
    }
}
