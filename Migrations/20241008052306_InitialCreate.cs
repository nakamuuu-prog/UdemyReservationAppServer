using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UdemyReservationAppServer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CoverImage = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Heading1 = table.Column<string>(type: "TEXT", nullable: false),
                    Heading2 = table.Column<string>(type: "TEXT", nullable: false),
                    Heading3 = table.Column<string>(type: "TEXT", nullable: false),
                    HeadingText1 = table.Column<string>(type: "TEXT", nullable: false),
                    HeadingText2 = table.Column<string>(type: "TEXT", nullable: false),
                    HeadingText3 = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CoverImage", "Description", "Heading1", "Heading2", "Heading3", "HeadingText1", "HeadingText2", "HeadingText3", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "./assets/img/phone-cover.jpg", "A large phone with one of the best screens", "Edge-to-Edge Display", "Facial recognition", "Powerful chip", "The Phone XL introduced a 5.8-inch display with minimal bezels, offering an immersive viewing experience and vibrant colors.", "It was the first Phone to replace the fingerprint sensor with facial recognition technology for unlocking the phone and authentication.", "The Phone XL featured powerful chip, which enhanced performance, efficiency, and supported advanced augmented reality (AR) applications.", "Phone XL", 799m },
                    { 2, "./assets/img/phone-cover.jpg", "A great phone with one of the best cameras", "Phone Mini heading1", "Phone Mini heading2", "Phone Mini heading3", "Phone Mini headingText1", "Phone Mini headingText2", "Phone Mini headingText3", "Phone Mini", 699m },
                    { 3, "./assets/img/phone-cover.jpg", "", "Phone Standard heading1", "Phone Standard heading2", "Phone Standard heading3", "Phone Standard headingText1", "Phone Standard headingText2", "Phone Standard headingText3", "Phone Standard", 299m },
                    { 4, "./assets/img/phone-cover.jpg", "", "Phone Special heading1", "Phone Special heading2", "Phone Special heading3", "Phone Special headingText1", "Phone Special headingText2", "Phone Special headingText3", "Phone Special", 900m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
