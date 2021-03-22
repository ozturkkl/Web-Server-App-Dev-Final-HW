﻿// <auto-generated />
using GamesIPlay.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GamesIPlay.Migrations
{
    [DbContext(typeof(GamesIPlayContext))]
    partial class GamesIPlayContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GamesIPlay.Models.Game", b =>
                {
                    b.Property<int>("GameID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Favorite")
                        .HasColumnType("bit");

                    b.Property<int>("GenreID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GameID");

                    b.HasIndex("GenreID");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            GameID = 1,
                            Description = "This is a physics based multiplayer online competitive game. In this game you use cars to play soccer, the objective is the score the most goals before the timer runs out.",
                            Favorite = false,
                            GenreID = 1,
                            Name = "Rocket League"
                        },
                        new
                        {
                            GameID = 2,
                            Description = "This game is a MOBA(Multiplayer Online Battle Arena). The objective is to capture the enemy teams base and destroy their units. It has the biggest prize pool amongst all e-sports games. I am planning to go to the live international championship one day after the virus.",
                            Favorite = false,
                            GenreID = 1,
                            Name = "Dota 2"
                        },
                        new
                        {
                            GameID = 3,
                            Description = "A well known RPG where you can explore the vast world and go on adventures. There are multiple classes and occupations to choose, although the game came out in 2011, it is still an amazing experience.",
                            Favorite = false,
                            GenreID = 2,
                            Name = "Elder Scrolls V: Skyrim"
                        },
                        new
                        {
                            GameID = 4,
                            Description = "An indie game that recently gained popularity, it is a chill and relaxing experience. The game is a survival game where you can fight monsters and kill bosses, you can also build your own base with the modular base building system!",
                            Favorite = false,
                            GenreID = 3,
                            Name = "Valheim"
                        });
                });

            modelBuilder.Entity("GamesIPlay.Models.Genre", b =>
                {
                    b.Property<int>("GenreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreID");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreID = 1,
                            Name = "Multiplayer"
                        },
                        new
                        {
                            GenreID = 2,
                            Name = "Singleplayer"
                        },
                        new
                        {
                            GenreID = 3,
                            Name = "Co-Op"
                        });
                });

            modelBuilder.Entity("GamesIPlay.Models.Game", b =>
                {
                    b.HasOne("GamesIPlay.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}
