using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAPC9Y__SOF__2023241.Migrations
{
    public partial class seedUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Champions",
                keyColumn: "Id",
                keyValue: "123",
                column: "Name",
                value: "Tahm Kench");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Champions",
                keyColumn: "Id",
                keyValue: "123",
                column: "Name",
                value: "Tahm Kech");
        }
    }
}
