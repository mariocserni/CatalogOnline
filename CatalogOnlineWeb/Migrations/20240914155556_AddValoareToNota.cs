using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogOnlineWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddValoareToNota : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Valoare",
                table: "Note",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valoare",
                table: "Note");
        }
    }
}
