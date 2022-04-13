using Microsoft.EntityFrameworkCore.Migrations;

namespace MundiUtil.WEB.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "insumo",
                columns: table => new
                {
                    IdInsumos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreInsumo = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ReferenciaInsumo = table.Column<int>(type: "int", nullable: false),
                    TipoInsumo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insumo", x => x.IdInsumos);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "insumo");
        }
    }
}
