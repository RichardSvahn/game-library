#nullable disable
using Microsoft.EntityFrameworkCore;

    public class GameContext : DbContext
    {
        public GameContext (DbContextOptions<GameContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
            .Property<int>("PublisherForeignKey");

            modelBuilder.Entity<Game>()
            .HasMany(g => g.Genres)
            .WithMany(c => c.Games);

            modelBuilder.Entity<Game>()
            .HasOne(g => g.Publisher)
            .WithMany(c => c.Games)
            .HasForeignKey("PublisherForeignKey");

            modelBuilder.Entity<Game>().Navigation(c => c.Genres).AutoInclude();
            modelBuilder.Entity<Game>().Navigation(c => c.Publisher).AutoInclude();
        }

        public DbSet<Game> Game { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
    }
