using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroVision.Database.Context.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgrochemicalСharacteristics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DistrictName = table.Column<string>(type: "text", nullable: false),
                    MobilePhosphorus = table.Column<double>(type: "double precision", nullable: false),
                    MobileKalium = table.Column<double>(type: "double precision", nullable: false),
                    SaltExtract = table.Column<double>(type: "double precision", nullable: false),
                    Humus = table.Column<double>(type: "double precision", nullable: false),
                    GrainYield = table.Column<double>(type: "double precision", nullable: false),
                    PotatoYield = table.Column<double>(type: "double precision", nullable: false),
                    SunflowerYield = table.Column<double>(type: "double precision", nullable: false),
                    OpenGroundVegetablesYield = table.Column<double>(type: "double precision", nullable: false),
                    Srup = table.Column<double>(type: "double precision", nullable: false),
                    SoilGradation = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgrochemicalСharacteristics", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgrochemicalСharacteristics");
        }
    }
}
