using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Academia.Migrations
{
    public partial class Comenzarmigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hojadevida",
                columns: table => new
                {
                    HojadevidaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpleadoID = table.Column<int>(nullable: false),
                    Especialidad = table.Column<string>(maxLength: 20, nullable: false),
                    TiempoExperiencia = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hojadevida", x => x.HojadevidaID);
                    table.ForeignKey(
                        name: "FK_Hojadevida_Empleado_EmpleadoID",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hojadevida_EmpleadoID",
                table: "Hojadevida",
                column: "EmpleadoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hojadevida");
        }
    }
}
