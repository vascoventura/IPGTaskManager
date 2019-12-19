using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IPGManager.Migrations
{
    public partial class professorv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professor_Departamento_DepartamentoId",
                table: "Professor");

            migrationBuilder.DropForeignKey(
                name: "FK_Professor_Horario_HorarioId",
                table: "Professor");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Cargo_CargoId",
                table: "Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Tarefa_CargoId",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "CargoId",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "HorarioId",
                table: "Professor");

            migrationBuilder.DropColumn(
                name: "Apelido",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "Contacto",
                table: "Funcionario");

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoTarefa",
                table: "Tarefa",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "Professor",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Contacto",
                table: "Professor",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Professor",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Professor",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Professor",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Funcionario",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Professor",
                table: "Professor",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Professor",
                table: "Professor");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Professor");

            migrationBuilder.DropColumn(
                name: "Contacto",
                table: "Professor");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Professor");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Professor");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Professor");

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoTarefa",
                table: "Tarefa",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CargoId",
                table: "Tarefa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HorarioId",
                table: "Professor",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Apelido",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Contacto",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_CargoId",
                table: "Tarefa",
                column: "CargoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_Departamento_DepartamentoId",
                table: "Professor",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "DepartamentoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_Horario_HorarioId",
                table: "Professor",
                column: "HorarioId",
                principalTable: "Horario",
                principalColumn: "HorarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Cargo_CargoId",
                table: "Tarefa",
                column: "CargoId",
                principalTable: "Cargo",
                principalColumn: "CargoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
