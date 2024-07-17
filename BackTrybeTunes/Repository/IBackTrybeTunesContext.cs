using BackTrybeTunes.Models;
using Microsoft.EntityFrameworkCore;

namespace BackTrybeTunes.Repository;

public interface IBackTrybeTunesContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public int SaveChanges();
}