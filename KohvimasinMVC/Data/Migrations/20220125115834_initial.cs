using Microsoft.EntityFrameworkCore.Migrations;

namespace KohvimasinMVC.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kohvimasin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jooginimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Topsepakis = table.Column<int>(type: "int", nullable: false),
                    Topsejuua = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kohvimasin", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kohvimasin");
        }
    }
}
