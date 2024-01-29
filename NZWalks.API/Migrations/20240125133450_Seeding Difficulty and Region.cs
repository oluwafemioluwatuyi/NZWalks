using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDifficultyandRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0c8cb674-f1f9-4f9f-ad1e-c40e7124481e"), "WGN", "Wellington", null },
                    { new Guid("720ae01e-ff1f-4159-a541-554fe89b13c3"), "NSN", "Nelson", null },
                    { new Guid("7748f429-6407-4ab1-837f-7c5de0f65e12"), "NTL", "Northland", null },
                    { new Guid("93e3b356-9b99-40c3-86c5-4252213935fd"), "STL", "Southland", null },
                    { new Guid("dc1307ed-e03b-434b-8e6b-b6f3b241bc49"), "AKL", "Auckland", "" },
                    { new Guid("f689f64e-67c9-491a-b275-ffb126cc92ef"), "BOP", "Bay of Plenty", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0c8cb674-f1f9-4f9f-ad1e-c40e7124481e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("720ae01e-ff1f-4159-a541-554fe89b13c3"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7748f429-6407-4ab1-837f-7c5de0f65e12"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("93e3b356-9b99-40c3-86c5-4252213935fd"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("dc1307ed-e03b-434b-8e6b-b6f3b241bc49"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f689f64e-67c9-491a-b275-ffb126cc92ef"));
        }
    }
}
