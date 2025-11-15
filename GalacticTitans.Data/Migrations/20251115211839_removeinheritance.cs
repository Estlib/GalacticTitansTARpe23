using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalacticTitans.Data.Migrations
{
    /// <inheritdoc />
    public partial class removeinheritance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Titans_PlayerProfiles_PlayerProfileID",
                table: "Titans");

            migrationBuilder.DropIndex(
                name: "IX_Titans_PlayerProfileID",
                table: "Titans");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Titans");

            migrationBuilder.DropColumn(
                name: "IsOwnershipOfThisTitan",
                table: "Titans");

            migrationBuilder.DropColumn(
                name: "OwnedByPlayerProfile",
                table: "Titans");

            migrationBuilder.DropColumn(
                name: "OwnershipCreatedAt",
                table: "Titans");

            migrationBuilder.DropColumn(
                name: "OwnershipID",
                table: "Titans");

            migrationBuilder.DropColumn(
                name: "OwnershipUpdatedAt",
                table: "Titans");

            migrationBuilder.DropColumn(
                name: "PlayerProfileID",
                table: "Titans");

            migrationBuilder.CreateTable(
                name: "TitanOwnerships",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TitanName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitanType = table.Column<int>(type: "int", nullable: false),
                    TitanHealth = table.Column<int>(type: "int", nullable: false),
                    TitanXP = table.Column<int>(type: "int", nullable: false),
                    TitanXPNextLevel = table.Column<int>(type: "int", nullable: false),
                    TitanLevel = table.Column<int>(type: "int", nullable: false),
                    TitanStatus = table.Column<int>(type: "int", nullable: false),
                    PrimaryAttackName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryAttackPower = table.Column<int>(type: "int", nullable: false),
                    SecondaryAttackName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryAttackPower = table.Column<int>(type: "int", nullable: false),
                    SpecialAttackName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialAttackPower = table.Column<int>(type: "int", nullable: false),
                    TitanWasBorn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TitanDied = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnedByPlayerProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOwnershipOfThisTitan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnershipCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnershipUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlayerProfileID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitanOwnerships", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TitanOwnerships_PlayerProfiles_PlayerProfileID",
                        column: x => x.PlayerProfileID,
                        principalTable: "PlayerProfiles",
                        principalColumn: "ID");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10000000-1000-1000-1000-100010001000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "aa7bb331-3ebd-4476-b19f-9118868c8d85", "e223a6d5-7e5c-4c61-8734-f164adee30be" });

            migrationBuilder.CreateIndex(
                name: "IX_TitanOwnerships_PlayerProfileID",
                table: "TitanOwnerships",
                column: "PlayerProfileID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TitanOwnerships");

            migrationBuilder.DeleteData(
                table: "Titans",
                keyColumn: "ID",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Titans",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<DateTime>(
                name: "OwnershipCreatedAt",
                table: "Titans",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnershipID",
                table: "Titans",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OwnershipUpdatedAt",
                table: "Titans",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerProfileID",
                table: "Titans",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10000000-1000-1000-1000-100010001000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f2f6a02b-2f2e-4f52-8466-2a8ca7fffc9b", "54247cd9-3935-4b45-9711-ab516857f17b" });

            migrationBuilder.InsertData(
                table: "Titans",
                columns: new[] { "ID", "CreatedAt", "Discriminator", "PrimaryAttackName", "PrimaryAttackPower", "SecondaryAttackName", "SecondaryAttackPower", "SpecialAttackName", "SpecialAttackPower", "TitanDied", "TitanHealth", "TitanLevel", "TitanName", "TitanStatus", "TitanType", "TitanWasBorn", "TitanXP", "TitanXPNextLevel", "UpdatedAt" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Titan", "Primary Attack", 0, "Secondary Attack", 0, "Special Attack", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Seed Titan", 1, 12, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 100, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Titans_PlayerProfileID",
                table: "Titans",
                column: "PlayerProfileID");

            migrationBuilder.AddForeignKey(
                name: "FK_Titans_PlayerProfiles_PlayerProfileID",
                table: "Titans",
                column: "PlayerProfileID",
                principalTable: "PlayerProfiles",
                principalColumn: "ID");
        }
    }
}
