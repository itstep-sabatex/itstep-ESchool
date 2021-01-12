using Microsoft.EntityFrameworkCore.Migrations;

namespace ESchoolRazor.Data.Migrations
{
    public partial class FormOfEducation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormOfEducation",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormOfEducation",
                table: "Students");
        }
    }
}
