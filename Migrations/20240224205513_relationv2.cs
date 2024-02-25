using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCenter.Migrations
{
    /// <inheritdoc />
    public partial class relationv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecialityID",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Speciality_SpecialityID",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_SpecialityID",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "SpecialityID",
                table: "Appointments");
        }
    }
}
