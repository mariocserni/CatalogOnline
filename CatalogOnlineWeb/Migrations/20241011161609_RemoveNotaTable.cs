using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogOnlineWeb.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNotaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.AlterColumn<int>(
                name: "An",
                table: "Studenti",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Credite",
                table: "Discipline",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "NotaParcurs",
                table: "Contracte",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NotaPrezentarea1",
                table: "Contracte",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NotaPrezentarea2",
                table: "Contracte",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NotaPrezentarea3",
                table: "Contracte",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Credite",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "NotaParcurs",
                table: "Contracte");

            migrationBuilder.DropColumn(
                name: "NotaPrezentarea1",
                table: "Contracte");

            migrationBuilder.DropColumn(
                name: "NotaPrezentarea2",
                table: "Contracte");

            migrationBuilder.DropColumn(
                name: "NotaPrezentarea3",
                table: "Contracte");

            migrationBuilder.AlterColumn<int>(
                name: "An",
                table: "Studenti",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    NotaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valoare = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.NotaId);
                    table.ForeignKey(
                        name: "FK_Note_Contracte_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracte",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Note_ContractId",
                table: "Note",
                column: "ContractId");
        }
    }
}
