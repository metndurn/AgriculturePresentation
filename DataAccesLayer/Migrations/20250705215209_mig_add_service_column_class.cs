﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_service_column_class : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Class1",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LogoImage",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class1",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "LogoImage",
                table: "Services");
        }
    }
}
