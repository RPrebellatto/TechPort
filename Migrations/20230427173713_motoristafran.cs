using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechPort.Migrations
{
    public partial class motoristafran : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MotoristaId",
                table: "VidasConteiner",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Motorista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CNH = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorista", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VidasConteiner_Motorista_MotoristaId",
                table: "VidasConteiner");

            migrationBuilder.DropTable(
                name: "Motorista");

            migrationBuilder.DropIndex(
                name: "IX_VidasConteiner_MotoristaId",
                table: "VidasConteiner");

            migrationBuilder.DropColumn(
                name: "MotoristaId",
                table: "VidasConteiner");
        }
    }
}
