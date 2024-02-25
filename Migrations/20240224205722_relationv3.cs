using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCenter.Migrations
{
    /// <inheritdoc />
    public partial class relationv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecialityID",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpecialityID1",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecialityID",
                table: "Doctors",
                column: "SpecialityID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecialityID1",
                table: "Doctors",
                column: "SpecialityID1",
                unique: true,
                filter: "[SpecialityID1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Speciality_SpecialityID",
                table: "Doctors",
                column: "SpecialityID",
                principalTable: "Speciality",
                principalColumn: "SpecialityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Speciality_SpecialityID1",
                table: "Doctors",
                column: "SpecialityID1",
                principalTable: "Speciality",
                principalColumn: "SpecialityID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Speciality_SpecialityID",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Speciality_SpecialityID1",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_SpecialityID",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_SpecialityID1",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "SpecialityID",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "SpecialityID1",
                table: "Doctors");
        }
    }
}
