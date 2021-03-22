using Microsoft.EntityFrameworkCore.Migrations;

namespace GamesIPlay.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreID);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                    table.ForeignKey(
                        name: "FK_Games_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreID", "Name" },
                values: new object[] { 1, "Multiplayer" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreID", "Name" },
                values: new object[] { 2, "Singleplayer" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreID", "Name" },
                values: new object[] { 3, "Co-Op" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "Description", "GenreID", "Name" },
                values: new object[,]
                {
                    { 1, "This is a physics based multiplayer online competitive game. In this game you use cars to play soccer, the objective is the score the most goals before the timer runs out.", 1, "Rocket League" },
                    { 2, "This game is a MOBA(Multiplayer Online Battle Arena). The objective is to capture the enemy teams base and destroy their units. It has the biggest prize pool amongst all e-sports games. I am planning to go to the live international championship one day after the virus.", 1, "Dota 2" },
                    { 3, "A well known RPG where you can explore the vast world and go on adventures. There are multiple classes and occupations to choose, although the game came out in 2011, it is still an amazing experience.", 2, "Elder Scrolls V: Skyrim" },
                    { 4, "An indie game that recently gained popularity, it is a chill and relaxing experience. The game is a survival game where you can fight monsters and kill bosses, you can also build your own base with the modular base building system!", 3, "Valheim" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_GenreID",
                table: "Games",
                column: "GenreID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
