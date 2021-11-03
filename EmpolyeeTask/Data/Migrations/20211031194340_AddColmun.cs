using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpolyeeTask.Data.Migrations
{
    public partial class AddColmun : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeesId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentsID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentsID",
                table: "AspNetUsers",
                column: "DepartmentsID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentsID",
                table: "AspNetUsers",
                column: "DepartmentsID",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentsID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DepartmentsID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmployeesId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DepartmentsID",
                table: "AspNetUsers");
        }
    }
}
