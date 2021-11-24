using Microsoft.EntityFrameworkCore.Migrations;

namespace TemperatureProject.Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TemperatureOriginData2",
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
                    table.PrimaryKey("PK_TemperatureOriginData2", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemperatureOriginData2");
        }
    }
}
