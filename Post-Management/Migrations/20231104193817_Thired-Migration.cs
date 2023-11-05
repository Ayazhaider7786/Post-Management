using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Post_Management.Migrations
{
    /// <inheritdoc />
    public partial class ThiredMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "myBlogPost",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "myBlogPost");
        }
    }
}
