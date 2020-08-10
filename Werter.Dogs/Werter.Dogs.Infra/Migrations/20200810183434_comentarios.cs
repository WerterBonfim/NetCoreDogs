using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Werter.Dogs.Infra.Migrations
{
    public partial class comentarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "TB_Fotos",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TB_Fotos",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateTable(
                name: "TB_Comentarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(nullable: false),
                    FotoId = table.Column<Guid>(nullable: true),
                    UsuarioId = table.Column<Guid>(nullable: true),
                    Texto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Comentarios_TB_Fotos_FotoId",
                        column: x => x.FotoId,
                        principalTable: "TB_Fotos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_Comentarios_TB_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TB_Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Comentarios_FotoId",
                table: "TB_Comentarios",
                column: "FotoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Comentarios_UsuarioId",
                table: "TB_Comentarios",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Comentarios");

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "TB_Fotos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TB_Fotos",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);
        }
    }
}
