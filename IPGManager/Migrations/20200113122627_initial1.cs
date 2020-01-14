using Microsoft.EntityFrameworkCore.Migrations;

namespace IPGManager.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professor_Departamento_DepartamentoId",
                table: "Professor");

            migrationBuilder.DropForeignKey(
                name: "FK_Professor_Horario_HorarioId",
                table: "Professor");

            migrationBuilder.DropIndex(
                name: "IX_Professor_DepartamentoId",
                table: "Professor");

            migrationBuilder.DropIndex(
                name: "IX_Professor_HorarioId",
                table: "Professor");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Professor");

            migrationBuilder.DropColumn(
                name: "HorarioId",
                table: "Professor");

            migrationBuilder.DropColumn(
                name: "Pnome",
                table: "Professor");

            migrationBuilder.DropColumn(
                name: "Unome",
                table: "Professor");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Professor",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "Professor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Professor",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    Genero = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Professor_GeneroId",
                table: "Professor",
                column: "GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_Generos_GeneroId",
                table: "Professor",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professor_Generos_GeneroId",
                table: "Professor");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropIndex(
                name: "IX_Professor_GeneroId",
                table: "Professor");

            migrationBuilder.DropColumn(
                name: "GeneroId",
                table: "Professor");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Professor");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Professor",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Professor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HorarioId",
                table: "Professor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Pnome",
                table: "Professor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Unome",
                table: "Professor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_DepartamentoId",
                table: "Professor",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_HorarioId",
                table: "Professor",
                column: "HorarioId");

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
        }
    }
}
