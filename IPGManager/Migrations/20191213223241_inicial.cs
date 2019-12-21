using Microsoft.EntityFrameworkCore.Migrations;

namespace IPGManager.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HorarioId",
                table: "Professor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Professor_HorarioId",
                table: "Professor",
                column: "HorarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_Horario_HorarioId",
                table: "Professor",
                column: "HorarioId",
                principalTable: "Horario",
                principalColumn: "HorarioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professor_Horario_HorarioId",
                table: "Professor");

            migrationBuilder.DropIndex(
                name: "IX_Professor_HorarioId",
                table: "Professor");

            migrationBuilder.DropColumn(
                name: "HorarioId",
                table: "Professor");
        }
    }
}
