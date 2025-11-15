using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalacticTitans.Data.Migrations
{
    /// <inheritdoc />
    public partial class titanownershipupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsOwnershipOfThisTitan",
                table: "Titans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnedByPlayerProfile",
                table: "Titans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10000000-1000-1000-1000-100010001000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f2f6a02b-2f2e-4f52-8466-2a8ca7fffc9b", "54247cd9-3935-4b45-9711-ab516857f17b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOwnershipOfThisTitan",
                table: "Titans");

            migrationBuilder.DropColumn(
                name: "OwnedByPlayerProfile",
                table: "Titans");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10000000-1000-1000-1000-100010001000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4062a806-9322-4c78-8ca8-8ec113a7188b", "0ef070ce-7d4d-49f3-9331-c1ac4b41243d" });
        }
    }
}
