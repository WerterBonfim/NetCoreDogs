using Microsoft.EntityFrameworkCore.Migrations;

namespace Werter.Dogs.Infra.Migrations
{
    public partial class removisrcfoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Src",
                table: "TB_Fotos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Src",
                table: "TB_Fotos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
