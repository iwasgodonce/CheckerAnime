﻿// <auto-generated />
using CheckerAnime.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CheckerAnime.Domain.Migrations
{
    [DbContext(typeof(CheckerAnimeContext))]
    partial class CheckerAnimeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CheckerAnime.Domain.Models.Anime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Animes");
                });

            modelBuilder.Entity("CheckerAnime.Domain.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Series")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VoiceAnimeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VoiceAnimeId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("CheckerAnime.Domain.Models.VoiceAnime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnimeId")
                        .HasColumnType("int");

                    b.Property<int>("VoiceStudioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimeId");

                    b.HasIndex("VoiceStudioId");

                    b.ToTable("VoiceAnimes");
                });

            modelBuilder.Entity("CheckerAnime.Domain.Models.VoiceStudio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VoiceStudios");
                });

            modelBuilder.Entity("CheckerAnime.Domain.Models.Notification", b =>
                {
                    b.HasOne("CheckerAnime.Domain.Models.VoiceAnime", "VoiceAnime")
                        .WithMany()
                        .HasForeignKey("VoiceAnimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VoiceAnime");
                });

            modelBuilder.Entity("CheckerAnime.Domain.Models.VoiceAnime", b =>
                {
                    b.HasOne("CheckerAnime.Domain.Models.Anime", "Anime")
                        .WithMany()
                        .HasForeignKey("AnimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CheckerAnime.Domain.Models.VoiceStudio", "VoiceStudio")
                        .WithMany()
                        .HasForeignKey("VoiceStudioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anime");

                    b.Navigation("VoiceStudio");
                });
#pragma warning restore 612, 618
        }
    }
}