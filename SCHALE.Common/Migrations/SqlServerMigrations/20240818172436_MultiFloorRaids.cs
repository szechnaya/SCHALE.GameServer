using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCHALE.Common.Migrations.SqlServerMigrations
{
    /// <inheritdoc />
    public partial class MultiFloorRaids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MultiFloorRaids",
                columns: table => new
                {
                    ServerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountServerId = table.Column<long>(type: "bigint", nullable: false),
                    SeasonId = table.Column<long>(type: "bigint", nullable: false),
                    ClearedDifficulty = table.Column<int>(type: "int", nullable: false),
                    LastClearDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RewardDifficulty = table.Column<int>(type: "int", nullable: false),
                    LastRewardDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClearBattleFrame = table.Column<int>(type: "int", nullable: false),
                    AllCleared = table.Column<bool>(type: "bit", nullable: false),
                    HasReceivableRewards = table.Column<bool>(type: "bit", nullable: false),
                    TotalReceivableRewards = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalReceivedRewards = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiFloorRaids", x => x.ServerId);
                    table.ForeignKey(
                        name: "FK_MultiFloorRaids_Accounts_AccountServerId",
                        column: x => x.AccountServerId,
                        principalTable: "Accounts",
                        principalColumn: "ServerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MultiFloorRaids_AccountServerId",
                table: "MultiFloorRaids",
                column: "AccountServerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MultiFloorRaids");
        }
    }
}
