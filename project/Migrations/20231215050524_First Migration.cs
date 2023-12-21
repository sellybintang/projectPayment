using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "projectPayment",
                columns: table => new
                {
                    paymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    cardNumber = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    expirationDate = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    securityCode = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectPayment", x => x.paymentId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "projectPayment");
        }
    }
}
