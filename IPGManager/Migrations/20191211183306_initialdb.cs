using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IPGManager.Migrations
{
    public partial class initialdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NivelCargo",
                table: "Cargo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    TarefaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTarefa = table.Column<string>(nullable: false),
                    DescricaoTarefa = table.Column<string>(nullable: true),
                    DataTarefa = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.TarefaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefa");

            migrationBuilder.DropColumn(
                name: "NivelCargo",
                table: "Cargo");
        }
    }
}
