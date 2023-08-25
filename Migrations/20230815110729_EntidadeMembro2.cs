using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ipcsmembros.Migrations
{
    /// <inheritdoc />
    public partial class EntidadeMembro2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diaconos");

            migrationBuilder.DropTable(
                name: "Presbiteros");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Membros",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Membros",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "Membros",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoMembro",
                table: "Membros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Membros");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Membros");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Membros");

            migrationBuilder.DropColumn(
                name: "TipoMembro",
                table: "Membros");

            migrationBuilder.CreateTable(
                name: "Diaconos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diaconos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Presbiteros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presbiteros", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Presbiteros_CPF",
                table: "Presbiteros",
                column: "CPF",
                unique: true);
        }
    }
}
