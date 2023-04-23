using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JesperCompanyAB.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HolidayLists");

            migrationBuilder.AddColumn<int>(
                name: "FK_UserId",
                table: "Holidays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FK_UserId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FK_UserId",
                table: "Holidays");

            migrationBuilder.DropColumn(
                name: "FK_UserId",
                table: "Employees");

            migrationBuilder.CreateTable(
                name: "HolidayLists",
                columns: table => new
                {
                    HolidayListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_EmployeeId = table.Column<int>(type: "int", nullable: false),
                    FK_HolidayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayLists", x => x.HolidayListId);
                    table.ForeignKey(
                        name: "FK_HolidayLists_Employees_FK_EmployeeId",
                        column: x => x.FK_EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HolidayLists_Holidays_FK_HolidayId",
                        column: x => x.FK_HolidayId,
                        principalTable: "Holidays",
                        principalColumn: "HolidayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HolidayLists_FK_EmployeeId",
                table: "HolidayLists",
                column: "FK_EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayLists_FK_HolidayId",
                table: "HolidayLists",
                column: "FK_HolidayId");
        }
    }
}
