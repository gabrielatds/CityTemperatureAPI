using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CityTemperatureAPI.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempAtual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TempMax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TempMin = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastConsult = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cidades");
        }
    }
}
