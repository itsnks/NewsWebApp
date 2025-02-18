using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsWebApp.Migrations
{
    /// <inheritdoc />
    public partial class addedTimeSinceCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TimeSinceCreation",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeSinceCreation",
                table: "Articles");
        }
    }
}
