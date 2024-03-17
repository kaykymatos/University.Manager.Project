using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Manager.Project.Financial.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewFieldsToCourseInstallmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstallmentsNumber",
                table: "CourseInstallments");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "CourseInstallments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "InstallmentStatus",
                table: "CourseInstallments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                table: "CourseInstallments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethod",
                table: "CourseInstallments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "CourseInstallments");

            migrationBuilder.DropColumn(
                name: "InstallmentStatus",
                table: "CourseInstallments");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "CourseInstallments");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "CourseInstallments");

            migrationBuilder.AddColumn<long>(
                name: "InstallmentsNumber",
                table: "CourseInstallments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
