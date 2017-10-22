using Microsoft.EntityFrameworkCore;

namespace Maple.Data.Core
{
    public class PlaylistContext : DbContext
    {
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<MediaItem> MediaItems { get; set; }
        public DbSet<MediaPlayer> Mediaplayers { get; set; }

        public PlaylistContext()
            : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=Maple.sqlite; Version=3; Pooling=True; Max Pool Size=100;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelConfiguration.Configure(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
