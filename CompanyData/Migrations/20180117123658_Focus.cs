using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CompanyData.Migrations
{
    public partial class Focus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FocusId",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Focus",
                columns: table => new
                {
                    FocusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FocusType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Focus", x => x.FocusId);
                });

            migrationBuilder.CreateTable(
                name: "CompanyFocus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    FocusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyFocus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyFocus_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyFocus_Focus_FocusId",
                        column: x => x.FocusId,
                        principalTable: "Focus",
                        principalColumn: "FocusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_FocusId",
                table: "Companies",
                column: "FocusId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyFocus_CompanyId",
                table: "CompanyFocus",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyFocus_FocusId",
                table: "CompanyFocus",
                column: "FocusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Focus_FocusId",
                table: "Companies",
                column: "FocusId",
                principalTable: "Focus",
                principalColumn: "FocusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Focus_FocusId",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "CompanyFocus");

            migrationBuilder.DropTable(
                name: "Focus");

            migrationBuilder.DropIndex(
                name: "IX_Companies_FocusId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "FocusId",
                table: "Companies");
        }
    }
}
