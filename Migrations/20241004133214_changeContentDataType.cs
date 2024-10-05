using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsWebApp.Migrations
{
    /// <inheritdoc />
    public partial class changeContentDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Articles",
                type: "nvarchar(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Articles",
                type: "varchar(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)");
        }
    }
}
