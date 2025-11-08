using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GalacticTitans.Data.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerProfileID", "ProfileType", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "10000000-1000-1000-1000-100010001000", 0, "testPassword1!", "4062a806-9322-4c78-8ca8-8ec113a7188b", "galactus@titanus.com", true, false, null, null, null, null, null, false, new Guid("10000000-1000-1000-1000-100010001000"), true, "0ef070ce-7d4d-49f3-9331-c1ac4b41243d", false, "galactus@titanus.com" });

            migrationBuilder.InsertData(
                table: "AstralBodies",
                columns: new[] { "ID", "AstralBodyDescription", "AstralBodyName", "AstralBodyType", "CreatedAt", "EnvironmentBoost", "MajorSettlements", "ModifiedAt", "SolarSystemID", "TechnicalLevel", "TitanWhoOwnsThisPlanetID" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111112"), "Example sun in DB, do not use as actual planet", "Seed Sun", 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null },
                    { new Guid("11111111-1111-1111-1111-111111111113"), "Example planet in DB, do not use as actual planet", "Seed Planet", 13, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null }
                });

            migrationBuilder.InsertData(
                table: "PlayerProfiles",
                columns: new[] { "ID", "ApplicationUserID", "CurrentStatus", "GalacticCredits", "MySolarSystem", "ProfileAttributedToAnAccountUserAt", "ProfileCreatedAt", "ProfileModifiedAt", "ProfileStatusLastChangedAt", "ProfileType", "ScrapResource", "ScreenName", "Victories" },
                values: new object[] { new Guid("10000000-1000-1000-1000-100010001000"), "10000000-1000-1000-1000-100010001000", 0, 9999999, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 9999999, "DbAdminGT", 0 });

            migrationBuilder.InsertData(
                table: "SolarSystems",
                columns: new[] { "ID", "AstralBodyAtCenter", "AstralBodyAtCenterWithID", "AstralBodyIDs", "CreatedAt", "SolarSystemLore", "SolarSystemName", "UpdatedAt" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111114"), new Guid("11111111-1111-1111-1111-111111111112"), null, "[\"11111111-1111-1111-1111-111111111112\",\"11111111-1111-1111-1111-111111111113\"]", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Do not use this solar system for actual gameplay", "Seed solar system", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Titans",
                columns: new[] { "ID", "CreatedAt", "Discriminator", "PrimaryAttackName", "PrimaryAttackPower", "SecondaryAttackName", "SecondaryAttackPower", "SpecialAttackName", "SpecialAttackPower", "TitanDied", "TitanHealth", "TitanLevel", "TitanName", "TitanStatus", "TitanType", "TitanWasBorn", "TitanXP", "TitanXPNextLevel", "UpdatedAt" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Titan", "Primary Attack", 0, "Secondary Attack", 0, "Special Attack", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Seed Titan", 1, 12, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 100, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10000000-1000-1000-1000-100010001000");

            migrationBuilder.DeleteData(
                table: "AstralBodies",
                keyColumn: "ID",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"));

            migrationBuilder.DeleteData(
                table: "AstralBodies",
                keyColumn: "ID",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"));

            migrationBuilder.DeleteData(
                table: "PlayerProfiles",
                keyColumn: "ID",
                keyValue: new Guid("10000000-1000-1000-1000-100010001000"));

            migrationBuilder.DeleteData(
                table: "SolarSystems",
                keyColumn: "ID",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"));

            migrationBuilder.DeleteData(
                table: "Titans",
                keyColumn: "ID",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));
        }
    }
}
