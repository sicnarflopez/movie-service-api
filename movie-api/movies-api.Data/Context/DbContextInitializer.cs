using Microsoft.EntityFrameworkCore;
using movies_api.Data.Entities;

namespace movies_api.Data.Context
{
    public class DbContextInitializer
    {
        private readonly MovieDbContext _context;

        public DbContextInitializer(MovieDbContext context)
        {
            _context = context;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                await _context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task SeedDefaultDataAsync()
        {
            try
            {
                await TrySeedDefaultDataAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task TrySeedDefaultDataAsync()
        {
            if (!_context.Movies.Any())
            {
                var movies = new List<Movie>
                {
                    new Movie { Title = "Inception", ReleaseYear = 2010, PosterUrl = "https://link/to/poster1.jpg" },
                    new Movie { Title = "The Matrix", ReleaseYear = 1999, PosterUrl = "https://link/to/poster2.jpg" },
                    new Movie { Title = "Interstellar", ReleaseYear = 2014, PosterUrl = "https://link/to/poster3.jpg" },
                    new Movie { Title = "The Dark Knight", ReleaseYear = 2008, PosterUrl = "https://link/to/poster4.jpg" },
                    new Movie { Title = "Pulp Fiction", ReleaseYear = 1994, PosterUrl = "https://link/to/poster5.jpg" },
                    new Movie { Title = "The Shawshank Redemption", ReleaseYear = 1994, PosterUrl = "https://link/to/poster6.jpg" },
                    new Movie { Title = "Forrest Gump", ReleaseYear = 1994, PosterUrl = "https://link/to/poster7.jpg" }
                };

                await _context.Movies.AddRangeAsync(movies);

                await _context.SaveChangesAsync();
            }
        }
    }
}
