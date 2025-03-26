using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clothingBrand",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clothingBrand", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "clothingItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    StoreID = table.Column<int>(type: "int", nullable: false),
                    tops = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    pants = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    outerwear = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    shoes = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clothingItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_clothingItems_clothingBrand1",
                        column: x => x.StoreID,
                        principalTable: "clothingBrand",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_clothingItems_StoreID",
                table: "clothingItems",
                column: "StoreID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clothingItems");

            migrationBuilder.DropTable(
                name: "clothingBrand");
        }
    }
}
