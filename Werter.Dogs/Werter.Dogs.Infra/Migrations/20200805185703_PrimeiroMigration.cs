using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Werter.Dogs.Infra.Migrations
{
    public partial class PrimeiroMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "TB_Usuarios",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 30, nullable: true),
                    NomeDeUsuario = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Senha = table.Column<string>(maxLength: 90, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_TB_Usuarios", x => x.Id); });

            migrationBuilder.CreateTable(
                "TB_Fotos",
                table => new
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
                        "FK_TB_Fotos_TB_Usuarios_UsuarioId",
                        x => x.UsuarioId,
                        "TB_Usuarios",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_TB_Fotos_UsuarioId",
                "TB_Fotos",
                "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "TB_Fotos");

            migrationBuilder.DropTable(
                "TB_Usuarios");
        }
    }
}