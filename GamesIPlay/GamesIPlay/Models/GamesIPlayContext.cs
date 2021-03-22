using Microsoft.EntityFrameworkCore;

namespace GamesIPlay.Models
{
    public class GamesIPlayContext : DbContext
    {
        public GamesIPlayContext(DbContextOptions<GamesIPlayContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreID = 1, Name = "Multiplayer" },
                new Genre { GenreID = 2, Name = "Singleplayer" },
                new Genre { GenreID = 3, Name = "Co-Op" }
            );

            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    GameID = 1, 
                    GenreID = 1,
                    Name = "Rocket League",
                    Description = "This is a physics based multiplayer online competitive game. In this game you use cars to play soccer, the objective is the score the most goals before the timer runs out."
                },
                new Game
                {
                    GameID = 2, 
                    GenreID = 1,
                    Name = "Dota 2",
                    Description = "This game is a MOBA(Multiplayer Online Battle Arena). The objective is to capture the enemy teams base and destroy their units. It has the biggest prize pool amongst all e-sports games. I am planning to go to the live international championship one day after the virus."
                },
                new Game
                {
                    GameID = 3, 
                    GenreID = 2,
                    Name = "Elder Scrolls V: Skyrim",
                    Description = "A well known RPG where you can explore the vast world and go on adventures. There are multiple classes and occupations to choose, although the game came out in 2011, it is still an amazing experience."
                },
                new Game
                {
                    GameID = 4, 
                    GenreID = 3,
                    Name = "Valheim",
                    Description = "An indie game that recently gained popularity, it is a chill and relaxing experience. The game is a survival game where you can fight monsters and kill bosses, you can also build your own base with the modular base building system!"
                }
            );
        }
    }
}