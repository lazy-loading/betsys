using Microsoft.EntityFrameworkCore.Migrations;

namespace BettingSystem.Web.Migrations
{
    public partial class UpdatedBets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bet_SportEvents_SportEventId",
                table: "Bet");

            migrationBuilder.DropForeignKey(
                name: "FK_Bet_Users_UserId1",
                table: "Bet");

            migrationBuilder.DropForeignKey(
                name: "FK_Selections_Bet_BetId",
                table: "Selections");

            migrationBuilder.DropIndex(
                name: "IX_Selections_BetId",
                table: "Selections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bet",
                table: "Bet");

            migrationBuilder.DropIndex(
                name: "IX_Bet_UserId1",
                table: "Bet");

            migrationBuilder.DropColumn(
                name: "BetId",
                table: "Selections");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Bet");

            migrationBuilder.RenameTable(
                name: "Bet",
                newName: "Bets");

            migrationBuilder.RenameIndex(
                name: "IX_Bet_SportEventId",
                table: "Bets",
                newName: "IX_Bets_SportEventId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bets",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<decimal>(
                name: "BetValue",
                table: "Bets",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "SelectionId",
                table: "Bets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bets",
                table: "Bets",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_SelectionId",
                table: "Bets",
                column: "SelectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_UserId",
                table: "Bets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Selections_SelectionId",
                table: "Bets",
                column: "SelectionId",
                principalTable: "Selections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_SportEvents_SportEventId",
                table: "Bets",
                column: "SportEventId",
                principalTable: "SportEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Users_UserId",
                table: "Bets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Selections_SelectionId",
                table: "Bets");

            migrationBuilder.DropForeignKey(
                name: "FK_Bets_SportEvents_SportEventId",
                table: "Bets");

            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Users_UserId",
                table: "Bets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bets",
                table: "Bets");

            migrationBuilder.DropIndex(
                name: "IX_Bets_SelectionId",
                table: "Bets");

            migrationBuilder.DropIndex(
                name: "IX_Bets_UserId",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "BetValue",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "SelectionId",
                table: "Bets");

            migrationBuilder.RenameTable(
                name: "Bets",
                newName: "Bet");

            migrationBuilder.RenameIndex(
                name: "IX_Bets_SportEventId",
                table: "Bet",
                newName: "IX_Bet_SportEventId");

            migrationBuilder.AddColumn<int>(
                name: "BetId",
                table: "Selections",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Bet",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Bet",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bet",
                table: "Bet",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Selections_BetId",
                table: "Selections",
                column: "BetId");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_UserId1",
                table: "Bet",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_SportEvents_SportEventId",
                table: "Bet",
                column: "SportEventId",
                principalTable: "SportEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_Users_UserId1",
                table: "Bet",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Selections_Bet_BetId",
                table: "Selections",
                column: "BetId",
                principalTable: "Bet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
