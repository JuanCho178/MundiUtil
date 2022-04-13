using Microsoft.EntityFrameworkCore.Migrations;

namespace MundiUtil.WEB.Migrations
{
    public partial class seagregalatablaClaseInsumo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clases",
                columns: table => new
                {
                    IdTipoInsumo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoInsumo = table.Column<string>(name: "Tipo Insumo", type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clases", x => x.IdTipoInsumo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clases");
        }
    }
}
