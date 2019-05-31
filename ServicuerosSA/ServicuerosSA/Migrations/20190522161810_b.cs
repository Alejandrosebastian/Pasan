using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServicuerosSA.Migrations
{
    public partial class b : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodegaCarnaza_1",
                columns: table => new
                {
                    BodegaCarnazaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BodegaId = table.Column<int>(nullable: false),
                    BodegaTripaId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<decimal>(nullable: false),
                    Codigo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodegaCarnaza_1", x => x.BodegaCarnazaId);
                    table.ForeignKey(
                        name: "FK_BodegaCarnaza_1_Bodega_BodegaId",
                        column: x => x.BodegaId,
                        principalTable: "Bodega",
                        principalColumn: "BodegaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BodegaCarnaza_1_Bodegatripa_BodegaTripaId",
                        column: x => x.BodegaTripaId,
                        principalTable: "Bodegatripa",
                        principalColumn: "BodegaTripaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BodegaCarnaza_1_BodegaId",
                table: "BodegaCarnaza_1",
                column: "BodegaId");

            migrationBuilder.CreateIndex(
                name: "IX_BodegaCarnaza_1_BodegaTripaId",
                table: "BodegaCarnaza_1",
                column: "BodegaTripaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodegaCarnaza_1");
        }
    }
}
