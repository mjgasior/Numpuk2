using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Numpuk2.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Examinations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    ClientId = table.Column<string>(nullable: true),
                    PhValue = table.Column<double>(nullable: true),
                    Consistency = table.Column<int>(nullable: false),
                    HasAkkermansiaMuciniphila = table.Column<bool>(nullable: true),
                    HasFaecalibactriumPrausnitzii = table.Column<bool>(nullable: true),
                    GeneralNumberOfBacteria = table.Column<double>(nullable: true),
                    MaterialRegistrationDate = table.Column<DateTime>(nullable: false),
                    ClientAge = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Examinations_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<double>(nullable: false),
                    ExaminationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_Examinations_ExaminationId",
                        column: x => x.ExaminationId,
                        principalTable: "Examinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_ClientId",
                table: "Examinations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_ExaminationId",
                table: "Results",
                column: "ExaminationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Examinations");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
