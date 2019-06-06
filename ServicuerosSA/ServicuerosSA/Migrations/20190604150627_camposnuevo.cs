using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServicuerosSA.Migrations
{
    public partial class camposnuevo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "codiunimedido",
                table: "Medido",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "codiunicalibrado",
                table: "Calibracion",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "codiunimedido",
                table: "Medido");

            migrationBuilder.DropColumn(
                name: "codiunicalibrado",
                table: "Calibracion");
        }
    }
}
