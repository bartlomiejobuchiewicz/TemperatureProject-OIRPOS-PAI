using Microsoft.EntityFrameworkCore.Migrations;

namespace TemperatureProject.Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TemperatureOriginData",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Czujnik1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Czujnik2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Czujnik3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemperatureOriginData", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "TemperatureOriginData",
                columns: new[] { "ID", "Czujnik1", "Czujnik2", "Czujnik3", "Data" },
                values: new object[,]
                {
                    { 1, "20.69", "21.44", "20.75", "16.10.2021 11:24:32" },
                    { 2, "20.81", "21.50", "20.81", "16.10.2021 11:25:33" },
                    { 3, "20.75", "21.56", "20.81", "16.10.2021 11:26:34" },
                    { 4, "20.81", "21.62", "20.81", "16.10.2021 11:27:35" },
                    { 5, "20.88", "21.62", "20.88", "16.10.2021 11:28:36" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemperatureOriginData");
        }
    }
}
