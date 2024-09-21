using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace newproj.Migrations
{
    /// <inheritdoc />
    public partial class imagecolumnremove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "users",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
