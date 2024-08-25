using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Envia.Migrations
{
    /// <inheritdoc />
    public partial class primera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroGuia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destinatario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoServicio = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    Cantidad = table.Column<double>(type: "float", nullable: false),
                    EsInternacional = table.Column<bool>(type: "bit", nullable: false),
                    EstadoGuides = table.Column<int>(type: "int", nullable: false),
                    ValorServicio = table.Column<double>(type: "float", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guias", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guias");
        }
    }
}
