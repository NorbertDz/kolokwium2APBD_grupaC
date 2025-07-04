﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace kolokwium2.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Race",
                columns: table => new
                {
                    RaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.RaceId);
                });

            migrationBuilder.CreateTable(
                name: "Racer",
                columns: table => new
                {
                    RacerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racer", x => x.RacerId);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    TrackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LengthInKm = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.TrackId);
                });

            migrationBuilder.CreateTable(
                name: "Track_Race",
                columns: table => new
                {
                    TrackRaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    Laps = table.Column<int>(type: "int", nullable: false),
                    BestTimeInSeconds = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track_Race", x => x.TrackRaceId);
                    table.ForeignKey(
                        name: "FK_Track_Race_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "RaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Track_Race_Track_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Track",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Race_Participation",
                columns: table => new
                {
                    TrackRaceId = table.Column<int>(type: "int", nullable: false),
                    RacerId = table.Column<int>(type: "int", nullable: false),
                    FinishTimeInSeconds = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race_Participation", x => new { x.TrackRaceId, x.RacerId });
                    table.ForeignKey(
                        name: "FK_Race_Participation_Racer_RacerId",
                        column: x => x.RacerId,
                        principalTable: "Racer",
                        principalColumn: "RacerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Race_Participation_Track_Race_TrackRaceId",
                        column: x => x.TrackRaceId,
                        principalTable: "Track_Race",
                        principalColumn: "TrackRaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Race",
                columns: new[] { "RaceId", "Date", "Location", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 10, 12, 38, 34, 755, DateTimeKind.Local).AddTicks(627), "Puerto Rico", "abcd" },
                    { 2, new DateTime(2025, 6, 10, 12, 38, 34, 756, DateTimeKind.Local).AddTicks(6015), "Warszawa", "gwef" },
                    { 3, new DateTime(2025, 6, 10, 12, 38, 34, 756, DateTimeKind.Local).AddTicks(6034), "Krakow", "dfg" }
                });

            migrationBuilder.InsertData(
                table: "Racer",
                columns: new[] { "RacerId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Jan", "Kwiatek" },
                    { 2, "Witold", "Ostatni" },
                    { 3, "Włodzimierz", "Kowalski" }
                });

            migrationBuilder.InsertData(
                table: "Track",
                columns: new[] { "TrackId", "LengthInKm", "Name" },
                values: new object[,]
                {
                    { 1, 20m, "tor numero uno" },
                    { 2, 15.5m, "ala ma kota" },
                    { 3, 20.3m, "kot ma ale" }
                });

            migrationBuilder.InsertData(
                table: "Track_Race",
                columns: new[] { "TrackRaceId", "BestTimeInSeconds", "Laps", "RaceId", "TrackId" },
                values: new object[,]
                {
                    { 1, 400, 50, 1, 1 },
                    { 2, 300, 45, 2, 3 },
                    { 3, 650, 32, 3, 2 },
                    { 4, 230, 23, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Race_Participation",
                columns: new[] { "RacerId", "TrackRaceId", "FinishTimeInSeconds", "Position" },
                values: new object[,]
                {
                    { 1, 1, 600, 1 },
                    { 2, 1, 601, 2 },
                    { 3, 1, 602, 3 },
                    { 1, 2, 500, 1 },
                    { 2, 2, 550, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Race_Participation_RacerId",
                table: "Race_Participation",
                column: "RacerId");

            migrationBuilder.CreateIndex(
                name: "IX_Track_Race_RaceId",
                table: "Track_Race",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Track_Race_TrackId",
                table: "Track_Race",
                column: "TrackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Race_Participation");

            migrationBuilder.DropTable(
                name: "Racer");

            migrationBuilder.DropTable(
                name: "Track_Race");

            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropTable(
                name: "Track");
        }
    }
}
