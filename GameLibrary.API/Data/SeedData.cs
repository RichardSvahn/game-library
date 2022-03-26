using Microsoft.EntityFrameworkCore;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new GameContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<GameContext>>()))
        {
            if (!context.Game.Any())
            {
                var BaseBuilder = new Genre
                {
                    Name = "Base Builder"
                };

                var Roguelite = new Genre
                {
                    Name = "Roguelite"
                };

                var OpenWorld = new Genre
                {
                    Name = "Open World"
                };

                var RPG = new Genre
                {
                    Name = "RPG"
                };

                var KleiEntertainment = new Publisher
                {
                    Name = "Klei Entertainment"
                };

                var Nicalis = new Publisher
                {
                    Name = "Nicalis"
                };

                var Bethesda = new Publisher
                {
                    Name = "Bethesda"
                };

                var ONI = new Game
                {
                    Name = "Oxygen not included",
                    Genres = new List<Genre>() {BaseBuilder},
                    Publisher = KleiEntertainment,
                    Released = DateTime.Now
                };


                var BoI = new Game
                {
                    Name = "Binding of Isaac",
                    Genres = new List<Genre>() {Roguelite},
                    Publisher = Nicalis,
                    Released = DateTime.Now
                };


                var Fallout4 = new Game
                {
                    Name = "Fallout 4",
                    Genres = new List<Genre>() {OpenWorld, RPG},
                    Publisher = Bethesda,
                    Released = DateTime.Now
                };

                context.Game.AddRange(ONI, BoI, Fallout4);
                context.SaveChanges();
            }
        }

    }
}