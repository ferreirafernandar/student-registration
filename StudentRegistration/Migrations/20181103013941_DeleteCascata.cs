using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentRegistration.Migrations
{
    public partial class DeleteCascata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Students_StudentId",
                table: "Phones");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Students_StudentId",
                table: "Phones",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Students_StudentId",
                table: "Phones");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Students_StudentId",
                table: "Phones",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
