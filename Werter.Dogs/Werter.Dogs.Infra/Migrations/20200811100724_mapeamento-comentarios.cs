using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Werter.Dogs.Infra.Migrations
{
    public partial class mapeamentocomentarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_TB_Comentarios_TB_Fotos_FotoId",
                "TB_Comentarios");

            migrationBuilder.DropForeignKey(
                "FK_TB_Comentarios_TB_Usuarios_UsuarioId",
                "TB_Comentarios");

            migrationBuilder.AlterColumn<Guid>(
                "UsuarioId",
                "TB_Comentarios",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                "FotoId",
                "TB_Comentarios",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                "FK_TB_Comentarios_TB_Fotos_FotoId",
                "TB_Comentarios",
                "FotoId",
                "TB_Fotos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                "FK_TB_Comentarios_TB_Usuarios_UsuarioId",
                "TB_Comentarios",
                "UsuarioId",
                "TB_Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_TB_Comentarios_TB_Fotos_FotoId",
                "TB_Comentarios");

            migrationBuilder.DropForeignKey(
                "FK_TB_Comentarios_TB_Usuarios_UsuarioId",
                "TB_Comentarios");

            migrationBuilder.AlterColumn<Guid>(
                "UsuarioId",
                "TB_Comentarios",
                "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                "FotoId",
                "TB_Comentarios",
                "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                "FK_TB_Comentarios_TB_Fotos_FotoId",
                "TB_Comentarios",
                "FotoId",
                "TB_Fotos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_TB_Comentarios_TB_Usuarios_UsuarioId",
                "TB_Comentarios",
                "UsuarioId",
                "TB_Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}