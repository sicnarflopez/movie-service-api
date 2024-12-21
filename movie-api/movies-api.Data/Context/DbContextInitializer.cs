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
                    new Movie { Title = "Inception", ReleaseYear = 2010, PosterUrl = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SX300.jpg" },
                    new Movie { Title = "The Matrix", ReleaseYear = 1999, PosterUrl = "https://m.media-amazon.com/images/M/MV5BN2NmN2VhMTQtMDNiOS00NDlhLTliMjgtODE2ZTY0ODQyNDRhXkEyXkFqcGc@._V1_SX300.jpgg" },
                    new Movie { Title = "Interstellar", ReleaseYear = 2014, PosterUrl = "https://m.media-amazon.com/images/M/MV5BYzdjMDAxZGItMjI2My00ODA1LTlkNzItOWFjMDU5ZDJlYWY3XkEyXkFqcGc@._V1_SX300.jpg" },
                    new Movie { Title = "The Dark Knight", ReleaseYear = 2008, PosterUrl = "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_SX300.jpg" },
                    new Movie { Title = "Pulp Fiction", ReleaseYear = 1994, PosterUrl = "https://m.media-amazon.com/images/M/MV5BYTViYTE3ZGQtNDBlMC00ZTAyLTkyODMtZGRiZDg0MjA2YThkXkEyXkFqcGc@._V1_SX300.jpg" },
                    new Movie { Title = "The Shawshank Redemption", ReleaseYear = 1994, PosterUrl = "https://m.media-amazon.com/images/M/MV5BMDAyY2FhYjctNDc5OS00MDNlLThiMGUtY2UxYWVkNGY2ZjljXkEyXkFqcGc@._V1_SX300.jpg" },
                    new Movie { Title = "Forrest Gump", ReleaseYear = 1994, PosterUrl = "https://m.media-amazon.com/images/M/MV5BNDYwNzVjMTItZmU5YS00YjQ5LTljYjgtMjY2NDVmYWMyNWFmXkEyXkFqcGc@._V1_SX300.jpg" }
                };

                await _context.Movies.AddRangeAsync(movies);

                await _context.SaveChangesAsync();
            }
        }
    }
}
