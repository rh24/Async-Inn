using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class addHotelData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "ID", "Address", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "49-27 219th St", "The Async Inn - Queens", "718-884-5535" },
                    { 2, "510 Madison Ave", "The Async Inn - Manhattan", "718-347-0990" },
                    { 3, "1080 Altantic Ave", "The Async Inn - Brooklyn", "347-888-8878" },
                    { 4, "4 Fairview Rd", "The Async Inn - Staten Island", "917-888-8878" },
                    { 5, "210 Dreiser Loop", "The Async Inn - Bronx", "718-616-3376" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
