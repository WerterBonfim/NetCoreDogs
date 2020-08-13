using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Werter.Dogs.Infra.Migrations
{
    public partial class ajustefoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                "UsuarioId",
                "TB_Fotos",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                "UsuarioId",
                "TB_Fotos",
                "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}