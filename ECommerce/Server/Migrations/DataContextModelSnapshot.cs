﻿// <auto-generated />
using System;
using ECommerce.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerce.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ECommerce.Shared.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Icon = "book",
                            Name = "Books",
                            Url = "books"
                        },
                        new
                        {
                            Id = 2,
                            Icon = "camera-slr",
                            Name = "Electronics",
                            Url = "electronics"
                        },
                        new
                        {
                            Id = 3,
                            Icon = "aperture",
                            Name = "Video Games",
                            Url = "video-games"
                        });
                });

            modelBuilder.Entity("ECommerce.Shared.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Views")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            DateCreated = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Hitchhiker's Guide to the Galaxy (sometimes referred to as HG2G, HHGTTG, H2G2, or tHGttG) is a comedy science fiction series created by Douglas Adams.",
                            Image = "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg",
                            OriginalPrice = 0m,
                            Price = 0m,
                            Quantity = 1,
                            Title = "The Hitchhiker's Guide to the Galaxy",
                            Views = 0
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            DateCreated = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune.",
                            Image = "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg",
                            OriginalPrice = 0m,
                            Price = 0m,
                            Quantity = 1,
                            Title = "Ready Player One",
                            Views = 0
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            DateCreated = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Nineteen Eighty-Four: A Novel, often published as 1984, is a dystopian social science fiction novel by English novelist George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime.",
                            Image = "https://upload.wikimedia.org/wikipedia/commons/c/c3/1984first.jpg",
                            OriginalPrice = 0m,
                            Price = 0m,
                            Quantity = 1,
                            Title = "Nineteen Eighty-Four",
                            Views = 0
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            DateCreated = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Pentax Spotmatic refers to a family of 35mm single-lens reflex cameras manufactured by the Asahi Optical Co. Ltd., later known as Pentax Corporation, between 1964 and 1976.",
                            Image = "https://upload.wikimedia.org/wikipedia/commons/e/e9/Honeywell-Pentax-Spotmatic.jpg",
                            OriginalPrice = 0m,
                            Price = 0m,
                            Quantity = 1,
                            Title = "Pentax Spotmatic",
                            Views = 0
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            DateCreated = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.",
                            Image = "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg",
                            OriginalPrice = 0m,
                            Price = 0m,
                            Quantity = 1,
                            Title = "Xbox",
                            Views = 0
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            DateCreated = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.",
                            Image = "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg",
                            OriginalPrice = 0m,
                            Price = 0m,
                            Quantity = 1,
                            Title = "Super Nintendo Entertainment System",
                            Views = 0
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            DateCreated = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.",
                            Image = "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg",
                            OriginalPrice = 0m,
                            Price = 0m,
                            Quantity = 1,
                            Title = "Half-Life 2",
                            Views = 0
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            DateCreated = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.",
                            Image = "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png",
                            OriginalPrice = 0m,
                            Price = 0m,
                            Quantity = 1,
                            Title = "Diablo II",
                            Views = 0
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            DateCreated = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.",
                            Image = "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg",
                            OriginalPrice = 0m,
                            Price = 0m,
                            Quantity = 1,
                            Title = "Day of the Tentacle",
                            Views = 0
                        });
                });

            modelBuilder.Entity("ECommerce.Shared.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TokenCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
