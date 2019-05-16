using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServicuerosSA.Migrations
{
    public partial class medio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "estanteria",
                table: "Medido",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "tipotri",
                table: "Medido",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tipoweb",
                table: "Medido",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estanteria",
                table: "Medido");

            migrationBuilder.DropColumn(
                name: "tipotri",
                table: "Medido");

            migrationBuilder.DropColumn(
                name: "tipoweb",
                table: "Medido");
        }
    }
}
