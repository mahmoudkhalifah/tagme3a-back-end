using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tagme3a_back_end.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addedOrderForJourneyMode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderForJourneyMode",
                table: "Categories",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderForJourneyMode",
                table: "Categories");
        }
    }
}
