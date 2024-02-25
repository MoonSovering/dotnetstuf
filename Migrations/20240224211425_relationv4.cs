using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCenter.Migrations
{
    /// <inheritdoc />
    public partial class relationv4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Speciality_SpecialityID",
                table: "Appointments");

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

            migrationBuilder.DropIndex(
                name: "IX_Appointments_SpecialityID",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "SpecialityID1",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "SpecialityID",
                table: "Appointments");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecialityID",
                table: "Doctors",
                column: "SpecialityID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Speciality_SpecialityID",
                table: "Doctors",
                column: "SpecialityID",
                principalTable: "Speciality",
                principalColumn: "SpecialityID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Speciality_SpecialityID",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_SpecialityID",
                table: "Doctors");

            migrationBuilder.AddColumn<int>(
                name: "SpecialityID1",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialityID",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_SpecialityID",
                table: "Appointments",
                column: "SpecialityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Speciality_SpecialityID",
                table: "Appointments",
                column: "SpecialityID",
                principalTable: "Speciality",
                principalColumn: "SpecialityID",
                onDelete: ReferentialAction.Cascade);

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
    }
}
