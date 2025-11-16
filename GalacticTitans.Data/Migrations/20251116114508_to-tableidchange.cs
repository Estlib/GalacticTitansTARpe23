using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalacticTitans.Data.Migrations
{
    /// <inheritdoc />
    public partial class totableidchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "TitanOwnerships",
                newName: "TitanOwnershipID");

            migrationBuilder.AddColumn<Guid>(
                name: "TitanOwnershipID",
                table: "FilesToDatabase",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10000000-1000-1000-1000-100010001000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "45ef59a4-59e0-4e2b-97bc-aa08e938db4a", "484892fb-7438-4e7e-b310-d2cc1348b5af" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitanOwnershipID",
                table: "FilesToDatabase");

            migrationBuilder.RenameColumn(
                name: "TitanOwnershipID",
                table: "TitanOwnerships",
                newName: "ID");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10000000-1000-1000-1000-100010001000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "aa7bb331-3ebd-4476-b19f-9118868c8d85", "e223a6d5-7e5c-4c61-8734-f164adee30be" });
        }
    }
}
