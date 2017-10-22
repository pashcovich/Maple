using Microsoft.EntityFrameworkCore;

namespace Maple.Data.Core
{
    public static class ModelConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            ConfigureCoachEntity(modelBuilder);
            ConfigureMediaItemEntity(modelBuilder);
        }

        private static void ConfigureCoachEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MediaPlayer>()
                .OwnsOne(p => p.Playlist);
        }

        private static void ConfigureMediaItemEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MediaItem>()
                .HasOne(p => p.Playlist)
                .WithMany(mediaItem => mediaItem.MediaItems)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
