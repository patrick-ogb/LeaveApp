using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveApp.Core.Migrations
{
    public partial class AddForeignKeyToLeaveTypeAndProjCompletion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveTypetbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    NumberOfDays = table.Column<int>(nullable: false),
                    Discription = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypetbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequesttbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    LeaveTypeId = table.Column<int>(nullable: false),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    ApprovalDate = table.Column<DateTime>(nullable: false),
                    ApprovedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequesttbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequesttbl_Employeetbl_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employeetbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaveRequesttbl_LeaveTypetbl_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypetbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequesttbl_EmployeeId",
                table: "LeaveRequesttbl",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequesttbl_LeaveTypeId",
                table: "LeaveRequesttbl",
                column: "LeaveTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequesttbl");

            migrationBuilder.DropTable(
                name: "LeaveTypetbl");
        }
    }
}
