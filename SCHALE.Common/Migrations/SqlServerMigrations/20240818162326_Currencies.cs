using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCHALE.Common.Migrations.SqlServerMigrations
{
    /// <inheritdoc />
    public partial class Currencies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    ServerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountServerId = table.Column<long>(type: "bigint", nullable: false),
                    AccountLevel = table.Column<long>(type: "bigint", nullable: false),
                    AcademyLocationRankSum = table.Column<long>(type: "bigint", nullable: false),
                    CurrencyDict = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateTimeDict = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.ServerId);
                    table.ForeignKey(
                        name: "FK_Currencies_Accounts_AccountServerId",
                        column: x => x.AccountServerId,
                        principalTable: "Accounts",
                        principalColumn: "ServerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_AccountServerId",
                table: "Currencies",
                column: "AccountServerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
