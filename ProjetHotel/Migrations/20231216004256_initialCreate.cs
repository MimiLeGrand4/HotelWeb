using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetHotel.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chambres_TypeChambres_TypeChambreId",
                table: "Chambres");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Hotels_HotelId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_HotelId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PrixCenne",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TypeChambres",
                newName: "TypeChambreId");

            migrationBuilder.AddColumn<decimal>(
                name: "Prix",
                table: "Reservations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Satut",
                table: "Paiements",
                type: "VARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Méthode",
                table: "Paiements",
                type: "VARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "TypeChambreId",
                table: "Chambres",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Prix",
                table: "Chambres",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Chambres",
                type: "VARCHAR(6000)",
                maxLength: 6000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Chambres_TypeChambres_TypeChambreId",
                table: "Chambres",
                column: "TypeChambreId",
                principalTable: "TypeChambres",
                principalColumn: "TypeChambreId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chambres_TypeChambres_TypeChambreId",
                table: "Chambres");

            migrationBuilder.DropColumn(
                name: "Prix",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "TypeChambreId",
                table: "TypeChambres",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrixCenne",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Satut",
                table: "Paiements",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR");

            migrationBuilder.AlterColumn<string>(
                name: "Méthode",
                table: "Paiements",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR");

            migrationBuilder.AlterColumn<int>(
                name: "TypeChambreId",
                table: "Chambres",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Prix",
                table: "Chambres",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Chambres",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(6000)",
                oldMaxLength: 6000);

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Téléphone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_HotelId",
                table: "Reservations",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chambres_TypeChambres_TypeChambreId",
                table: "Chambres",
                column: "TypeChambreId",
                principalTable: "TypeChambres",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Hotels_HotelId",
                table: "Reservations",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
