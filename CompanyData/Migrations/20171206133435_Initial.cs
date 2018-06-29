using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CompanyData.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "ConstructionSkills",
                columns: table => new
                {
                    ConStrucSkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConstrucName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionSkills", x => x.ConStrucSkillId);
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagLine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobCatagory",
                columns: table => new
                {
                    JobCatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JobName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCatagory", x => x.JobCatId);
                });

            migrationBuilder.CreateTable(
                name: "SkillDetail",
                columns: table => new
                {
                    SkillDetailId = table.Column<int>(type: "int", nullable: false),
                    DetailName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillDetail", x => x.SkillDetailId);
                });

            migrationBuilder.CreateTable(
                name: "SkillSet",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillSet", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsConsultantCompany = table.Column<bool>(type: "bit", nullable: false),
                    IsInternalSystemCompany = table.Column<bool>(type: "bit", nullable: false),
                    IsProductCompany = table.Column<bool>(type: "bit", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillDetailId = table.Column<int>(type: "int", nullable: true),
                    SkillSetSkillId = table.Column<int>(type: "int", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Companies_SkillDetail_SkillDetailId",
                        column: x => x.SkillDetailId,
                        principalTable: "SkillDetail",
                        principalColumn: "SkillDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_SkillSet_SkillSetSkillId",
                        column: x => x.SkillSetSkillId,
                        principalTable: "SkillSet",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyCatagory",
                columns: table => new
                {
                    CompCatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    JobCatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCatagory", x => x.CompCatId);
                    table.ForeignKey(
                        name: "FK_CompanyCatagory_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyCatagory_JobCatagory_JobCatId",
                        column: x => x.JobCatId,
                        principalTable: "JobCatagory",
                        principalColumn: "JobCatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyDetails",
                columns: table => new
                {
                    CompanyDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    SkillDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDetails", x => x.CompanyDetailsId);
                    table.ForeignKey(
                        name: "FK_CompanyDetails_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyDetails_SkillDetail_SkillDetailId",
                        column: x => x.SkillDetailId,
                        principalTable: "SkillDetail",
                        principalColumn: "SkillDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanySkills",
                columns: table => new
                {
                    CompSkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanySkills", x => x.CompSkillId);
                    table.ForeignKey(
                        name: "FK_CompanySkills_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanySkills_SkillSet_SkillId",
                        column: x => x.SkillId,
                        principalTable: "SkillSet",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConstructionJunction",
                columns: table => new
                {
                    ConstrucJuncid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    ConStructId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionJunction", x => x.ConstrucJuncid);
                    table.ForeignKey(
                        name: "FK_ConstructionJunction_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConstructionJunction_ConstructionSkills_ConStructId",
                        column: x => x.ConStructId,
                        principalTable: "ConstructionSkills",
                        principalColumn: "ConStrucSkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_SkillDetailId",
                table: "Companies",
                column: "SkillDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_SkillSetSkillId",
                table: "Companies",
                column: "SkillSetSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCatagory_CompanyId",
                table: "CompanyCatagory",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCatagory_JobCatId",
                table: "CompanyCatagory",
                column: "JobCatId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDetails_CompanyId",
                table: "CompanyDetails",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDetails_SkillDetailId",
                table: "CompanyDetails",
                column: "SkillDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanySkills_CompanyId",
                table: "CompanySkills",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanySkills_SkillId",
                table: "CompanySkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionJunction_CompanyId",
                table: "ConstructionJunction",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionJunction_ConStructId",
                table: "ConstructionJunction",
                column: "ConStructId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "CompanyCatagory");

            migrationBuilder.DropTable(
                name: "CompanyDetails");

            migrationBuilder.DropTable(
                name: "CompanySkills");

            migrationBuilder.DropTable(
                name: "ConstructionJunction");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "JobCatagory");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "ConstructionSkills");

            migrationBuilder.DropTable(
                name: "SkillDetail");

            migrationBuilder.DropTable(
                name: "SkillSet");
        }
    }
}
