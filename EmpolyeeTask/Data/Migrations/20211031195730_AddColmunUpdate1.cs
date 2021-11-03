using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpolyeeTask.Data.Migrations
{
    public partial class AddColmunUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartId",
                table: "AspNetUsers");
        }
    }
}
