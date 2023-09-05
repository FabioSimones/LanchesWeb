using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesMac.Migrations
{
    public partial class MigracaoComDadosDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsLanchePrferido",
                table: "Lanches",
                newName: "IsLanchePreferido");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsLanchePreferido",
                table: "Lanches",
                newName: "IsLanchePrferido");
        }
    }
}
