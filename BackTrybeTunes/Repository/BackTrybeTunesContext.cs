using BackTrybeTunes.Models;
using Microsoft.EntityFrameworkCore;

namespace BackTrybeTunes.Repository
{
    public class BackTrybeTunesContext : DbContext, IBackTrybeTunesContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Track> Tracks { get; set; } = null!;

        public BackTrybeTunesContext(DbContextOptions<BackTrybeTunesContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var server = Environment.GetEnvironmentVariable("SERVER") ?? "localhost";
                var user = Environment.GetEnvironmentVariable("USERID") ?? "root";
                var password = Environment.GetEnvironmentVariable("PASSWORD") ?? "TrybeTunes123456!";
                var port = Environment.GetEnvironmentVariable("PORTMYSQL") ?? "3308";
                var database = Environment.GetEnvironmentVariable("DATABASE") ?? "TrybeTunes";

                var connectionString = $"Server={server};User Id={user};Port={port};Database={database};Password={password};";

                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), null);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Track>()
            .HasOne(track => track.User)
            .WithMany(user => user.Tracks)
            .HasForeignKey(track => track.UserId);
        }
    }
}
