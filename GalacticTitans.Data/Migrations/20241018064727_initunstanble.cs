﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalacticTitans.Data.Migrations
{
    /// <inheritdoc />
    public partial class initunstanble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Titans",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TitanName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitanHealth = table.Column<int>(type: "int", nullable: false),
                    TitanXP = table.Column<int>(type: "int", nullable: false),
                    TitanXPNextLevel = table.Column<int>(type: "int", nullable: false),
                    TitanLevel = table.Column<int>(type: "int", nullable: false),
                    TitanType = table.Column<int>(type: "int", nullable: false),
                    TitanStatus = table.Column<int>(type: "int", nullable: false),
                    PrimaryAttackPower = table.Column<int>(type: "int", nullable: false),
                    PrimaryAttackName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryAttackPower = table.Column<int>(type: "int", nullable: false),
                    SecondaryAttackName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialAttackPower = table.Column<int>(type: "int", nullable: false),
                    SpecialAttackName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitanWasBorn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TitanDied = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titans", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Titans");
        }
    }
}
