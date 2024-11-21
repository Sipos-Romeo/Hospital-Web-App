using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Repositories.Migrations
{
    public partial class HoptlInfoOptiomnl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_HospitalInfo_HospitalInfoId",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "HospitalInfoId",
                table: "Contacts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_HospitalInfo_HospitalInfoId",
                table: "Contacts",
                column: "HospitalInfoId",
                principalTable: "HospitalInfo",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_HospitalInfo_HospitalInfoId",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "HospitalInfoId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_HospitalInfo_HospitalInfoId",
                table: "Contacts",
                column: "HospitalInfoId",
                principalTable: "HospitalInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
