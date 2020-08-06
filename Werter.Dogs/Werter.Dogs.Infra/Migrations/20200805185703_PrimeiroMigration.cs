using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Werter.Dogs.Infra.Migrations
{
    public partial class PrimeiroMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 30, nullable: true),
                    NomeDeUsuario = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Senha = table.Column<string>(maxLength: 90, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Fotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 20, nullable: false),
                    Peso = table.Column<int>(nullable: false),
                    Idade = table.Column<int>(nullable: false),
                    Src = table.Column<string>(nullable: true),
                    QuantidadeDeAcessos = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Fotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Fotos_TB_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TB_Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Fotos_UsuarioId",
                table: "TB_Fotos",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Fotos");

            migrationBuilder.DropTable(
                name: "TB_Usuarios");
        }
    }
}
