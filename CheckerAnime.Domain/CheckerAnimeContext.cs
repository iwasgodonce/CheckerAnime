using CheckerAnime.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CheckerAnime.Domain
{
    public class CheckerAnimeContext : DbContext
    {
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<VoiceAnime> VoiceAnimes { get; set; }
        public DbSet<VoiceStudio> VoiceStudios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=checkerAnime;Trusted_Connection=True;");
        }
    }
}
