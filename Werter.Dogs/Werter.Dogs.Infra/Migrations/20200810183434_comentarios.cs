using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Werter.Dogs.Infra.Migrations
{
    public partial class comentarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                "UsuarioId",
                "TB_Fotos",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "Nome",
                "TB_Fotos",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateTable(
                "TB_Comentarios",
                table => new
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
                        "FK_TB_Comentarios_TB_Fotos_FotoId",
                        x => x.FotoId,
                        "TB_Fotos",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_TB_Comentarios_TB_Usuarios_UsuarioId",
                        x => x.UsuarioId,
                        "TB_Usuarios",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_TB_Comentarios_FotoId",
                "TB_Comentarios",
                "FotoId");

            migrationBuilder.CreateIndex(
                "IX_TB_Comentarios_UsuarioId",
                "TB_Comentarios",
                "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "TB_Comentarios");

            migrationBuilder.AlterColumn<Guid>(
                "UsuarioId",
                "TB_Fotos",
                "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                "Nome",
                "TB_Fotos",
                "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);
        }
    }
}