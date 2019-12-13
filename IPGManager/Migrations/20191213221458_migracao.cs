using Microsoft.EntityFrameworkCore.Migrations;

namespace IPGManager.Migrations
{
    public partial class migracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DescricaoTarefa",
                table: "Tarefa",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CargoId",
                table: "Tarefa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Unome",
                table: "Professor",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Pnome",
                table: "Professor",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Professor",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Contacto",
                table: "Professor",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Funcionario",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");

            migrationBuilder.AddColumn<string>(
                name: "Apelido",
                table: "Funcionario",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Contacto",
                table: "Funcionario",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_CargoId",
                table: "Tarefa",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_DepartamentoId",
                table: "Professor",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_Departamento_DepartamentoId",
                table: "Professor",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "DepartamentoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Cargo_CargoId",
                table: "Tarefa",
                column: "CargoId",
                principalTable: "Cargo",
                principalColumn: "CargoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professor_Departamento_DepartamentoId",
                table: "Professor");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Cargo_CargoId",
                table: "Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Tarefa_CargoId",
                table: "Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Professor_DepartamentoId",
                table: "Professor");

            migrationBuilder.DropColumn(
                name: "CargoId",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "Apelido",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "Contacto",
                table: "Funcionario");

            migrationBuilder.AlterColumn<string>(
                name: "DescricaoTarefa",
                table: "Tarefa",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Unome",
                table: "Professor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Pnome",
                table: "Professor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Professor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Contacto",
                table: "Professor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Funcionario",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
