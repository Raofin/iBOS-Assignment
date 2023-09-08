using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iBOS_Assignment.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    EmployeeCode = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    EmployeeSalary = table.Column<int>(nullable: false),
                    SupervisorId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAttendances",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsPresent = table.Column<bool>(nullable: false),
                    IsAbsent = table.Column<bool>(nullable: false),
                    IsOffDay = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeAttendances_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmployeeCode", "EmployeeName", "EmployeeSalary", "SupervisorId" },
                values: new object[,]
                {
                    { 502030L, "EMP320", "Mehedi Hasan", 50000, 502036L },
                    { 502031L, "EMP321", "Ashikur Rahman", 45000, 502036L },
                    { 502032L, "EMP322", "Rakibul Islam", 52000, 502030L },
                    { 502033L, "EMP323", "Hasan Abdullah", 46000, 502031L },
                    { 502034L, "EMP324", "Akib Khan", 66000, 502032L },
                    { 502035L, "EMP325", "Rasel Shikder", 53500, 502033L },
                    { 502036L, "EMP326", "Selim Reja", 59000, 502035L }
                });

            migrationBuilder.InsertData(
                table: "EmployeeAttendances",
                columns: new[] { "Id", "AttendanceDate", "EmployeeId", "IsAbsent", "IsOffDay", "IsPresent" },
                values: new object[] { 1L, new DateTime(2023, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030L, false, false, true });

            migrationBuilder.InsertData(
                table: "EmployeeAttendances",
                columns: new[] { "Id", "AttendanceDate", "EmployeeId", "IsAbsent", "IsOffDay", "IsPresent" },
                values: new object[] { 2L, new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030L, true, false, false });

            migrationBuilder.InsertData(
                table: "EmployeeAttendances",
                columns: new[] { "Id", "AttendanceDate", "EmployeeId", "IsAbsent", "IsOffDay", "IsPresent" },
                values: new object[] { 3L, new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031L, false, false, true });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendances_EmployeeId",
                table: "EmployeeAttendances",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAttendances");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
