using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IPGManager.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    IdCargo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCargo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.IdCargo);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    IdDepartamento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDepartamento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.IdDepartamento);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    IdHorario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HInicio = table.Column<DateTime>(nullable: false),
                    HInicioIntervalo = table.Column<DateTime>(nullable: false),
                    HFimIntervalo = table.Column<DateTime>(nullable: false),
                    HFim = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.IdHorario);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    IdFuncionarios = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    DataNascimento = table.Column<string>(nullable: false),
                    Sexo = table.Column<string>(nullable: false),
                    IdCargo = table.Column<int>(nullable: false),
                    CargoIdCargo = table.Column<int>(nullable: true),
                    IdDepartamento = table.Column<int>(nullable: false),
                    IdHorario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.IdFuncionarios);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Cargos_CargoIdCargo",
                        column: x => x.CargoIdCargo,
                        principalTable: "Cargos",
                        principalColumn: "IdCargo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_CargoIdCargo",
                table: "Funcionarios",
                column: "CargoIdCargo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Cargos");
        }
    }
}
