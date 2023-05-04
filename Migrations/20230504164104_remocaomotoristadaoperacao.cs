using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechPort.Migrations
{
    public partial class remocaomotoristadaoperacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VidasConteiner_Motorista_MotoristaId",
                table: "VidasConteiner");

            migrationBuilder.DropIndex(
                name: "IX_VidasConteiner_MotoristaId",
                table: "VidasConteiner");

            migrationBuilder.DropColumn(
                name: "MotoristaId",
                table: "VidasConteiner");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MotoristaId",
                table: "VidasConteiner",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VidasConteiner_MotoristaId",
                table: "VidasConteiner",
                column: "MotoristaId");

            migrationBuilder.AddForeignKey(
                name: "FK_VidasConteiner_Motorista_MotoristaId",
                table: "VidasConteiner",
                column: "MotoristaId",
                principalTable: "Motorista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
