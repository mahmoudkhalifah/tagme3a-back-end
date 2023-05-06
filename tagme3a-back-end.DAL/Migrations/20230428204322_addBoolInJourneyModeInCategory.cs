using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tagme3a_back_end.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addBoolInJourneyModeInCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InJourneyMode",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InJourneyMode",
                table: "Categories");
        }
    }
}
