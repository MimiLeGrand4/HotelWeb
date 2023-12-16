using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetHotel.Migrations
{
    /// <inheritdoc />
    public partial class inititalcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeChambreId",
                table: "Chambres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TypeChambres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeChambres", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chambres_TypeChambreId",
                table: "Chambres",
                column: "TypeChambreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chambres_TypeChambres_TypeChambreId",
                table: "Chambres",
                column: "TypeChambreId",
                principalTable: "TypeChambres",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chambres_TypeChambres_TypeChambreId",
                table: "Chambres");

            migrationBuilder.DropTable(
                name: "TypeChambres");

            migrationBuilder.DropIndex(
                name: "IX_Chambres_TypeChambreId",
                table: "Chambres");

            migrationBuilder.DropColumn(
                name: "TypeChambreId",
                table: "Chambres");
        }
    }
}
