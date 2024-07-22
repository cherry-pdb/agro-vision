using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroVision.Database.Context.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldDistinctId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "AgrochemicalСharacteristics",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "AgrochemicalСharacteristics");
        }
    }
}
