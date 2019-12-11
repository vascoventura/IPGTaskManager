using Microsoft.EntityFrameworkCore.Migrations;

namespace IPGManager.Migrations
{
    public partial class professores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professor_Departamento_DepartamentoId",
                table: "Professor");

            migrationBuilder.DropIndex(
                name: "IX_Professor_DepartamentoId",
                table: "Professor");

            migrationBuilder.RenameColumn(
                name: "UNome",
                table: "Professor",
                newName: "Unome");

            migrationBuilder.RenameColumn(
                name: "PNome",
                table: "Professor",
                newName: "Pnome");

            migrationBuilder.RenameColumn(
                name: "ProfessorID",
                table: "Professor",
                newName: "ProfessorId");

            migrationBuilder.AlterColumn<string>(
                name: "Unome",
                table: "Professor",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Pnome",
                table: "Professor",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "genero",
                table: "Professor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "genero",
                table: "Professor");

            migrationBuilder.RenameColumn(
                name: "Unome",
                table: "Professor",
                newName: "UNome");

            migrationBuilder.RenameColumn(
                name: "Pnome",
                table: "Professor",
                newName: "PNome");

            migrationBuilder.RenameColumn(
                name: "ProfessorId",
                table: "Professor",
                newName: "ProfessorID");

            migrationBuilder.AlterColumn<string>(
                name: "UNome",
                table: "Professor",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PNome",
                table: "Professor",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
