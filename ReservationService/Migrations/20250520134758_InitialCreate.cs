using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReservationService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Waitlist",
                columns: table => new
                {
                    TableId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waitlist", x => x.TableId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInput",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "TEXT", nullable: false),
                    Preferences = table.Column<string>(type: "TEXT", nullable: false),
                    WaitlistTableId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInput", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_CustomerInput_Waitlist_WaitlistTableId",
                        column: x => x.WaitlistTableId,
                        principalTable: "Waitlist",
                        principalColumn: "TableId");
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "Name" },
                values: new object[,]
                {
                    { "C101", "john.doe@example.com", "Jone Doe" },
                    { "C102", "jane.smith@example.com", "Jane Smith" },
                    { "C103", "sam.wilson@example.com", "Sam Wilson" },
                    { "C104", "emily.davis@example.com", "Emily Davis" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInput_WaitlistTableId",
                table: "CustomerInput",
                column: "WaitlistTableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerInput");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Waitlist");
        }
    }
}
