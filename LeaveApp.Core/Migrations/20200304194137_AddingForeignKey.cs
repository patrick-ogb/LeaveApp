using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveApp.Core.Migrations
{
    public partial class AddingForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departmentbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departmentbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leveltbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leveltbl", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employeetbl_DepartmentId",
                table: "Employeetbl",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employeetbl_LevelId",
                table: "Employeetbl",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employeetbl_Departmentbl_DepartmentId",
                table: "Employeetbl",
                column: "DepartmentId",
                principalTable: "Departmentbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employeetbl_Leveltbl_LevelId",
                table: "Employeetbl",
                column: "LevelId",
                principalTable: "Leveltbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employeetbl_Departmentbl_DepartmentId",
                table: "Employeetbl");

            migrationBuilder.DropForeignKey(
                name: "FK_Employeetbl_Leveltbl_LevelId",
                table: "Employeetbl");

            migrationBuilder.DropTable(
                name: "Departmentbl");

            migrationBuilder.DropTable(
                name: "Leveltbl");

            migrationBuilder.DropIndex(
                name: "IX_Employeetbl_DepartmentId",
                table: "Employeetbl");

            migrationBuilder.DropIndex(
                name: "IX_Employeetbl_LevelId",
                table: "Employeetbl");
        }
    }
}
