using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsWebApp.Migrations
{
    /// <inheritdoc />
    public partial class addImageDesc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageDescription",
                table: "Articles",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageDescription",
                table: "Articles");
        }
    }
}
