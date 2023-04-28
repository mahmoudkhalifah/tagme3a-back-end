using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tagme3a_back_end.DAL.Migrations
{
    /// <inheritdoc />
    public partial class PCupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "PCs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "PCs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "PCs");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "PCs");
        }
    }
}
