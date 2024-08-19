using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCHALE.Common.Migrations.SqlServerMigrations
{
    /// <inheritdoc />
    public partial class Cafe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cafes",
                columns: table => new
                {
                    ServerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountServerId = table.Column<long>(type: "bigint", nullable: false),
                    CafeDBId = table.Column<long>(type: "bigint", nullable: false),
                    CafeId = table.Column<long>(type: "bigint", nullable: false),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    CafeRank = table.Column<int>(type: "int", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastSummonDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CafeVisitCharacterDBs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FurnitureDBs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionAppliedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductionDB = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cafes", x => x.ServerId);
                    table.ForeignKey(
                        name: "FK_Cafes_Accounts_AccountServerId",
                        column: x => x.AccountServerId,
                        principalTable: "Accounts",
                        principalColumn: "ServerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cafes_AccountServerId",
                table: "Cafes",
                column: "AccountServerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cafes");
        }
    }
}
