using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace M8_Project2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accommodation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccommodationPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccommodationEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activity1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activity2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activity3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripId);
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "Accommodation", "AccommodationEmail", "AccommodationPhone", "Activity1", "Activity2", "Activity3", "Destination", "EndDate", "StartDate" },
                values: new object[] { 1, "The Benson Hotel", "staff@thebenson.com", "503-555-1234", "Get Voodoo donuts", "Walk in the rain", "Go to Powell's", "Portland", new DateTime(2024, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "Accommodation", "AccommodationEmail", "AccommodationPhone", "Activity1", "Activity2", "Activity3", "Destination", "EndDate", "StartDate" },
                values: new object[] { 2, "Holiday Inn Express", null, null, "Visit family", null, null, "Boise", new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
