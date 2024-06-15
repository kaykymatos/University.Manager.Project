using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Manager.Project.Student.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class StudentIdFieldDrop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Students");

            migrationBuilder.AddColumn<long>(
                name: "StudentId",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
