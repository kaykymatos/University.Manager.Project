using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Manager.Project.Student.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class FinancialIdColumnRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinancialId",
                table: "Students");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FinancialId",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
