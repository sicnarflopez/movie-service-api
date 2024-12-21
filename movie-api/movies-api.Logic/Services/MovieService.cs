using Microsoft.EntityFrameworkCore;
using movies_api.Data.Context;
using movies_api.Data.Entities;
using movies_api.Logic.Interfaces;

namespace movies_api.Logic.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieDbContext _context;
        public MovieService(IMovieDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetMoviesAsync(string? title)
        {
            return await _context.Movies.Where(m => m.Title.ToLower().Contains(title.ToLower()))
                                        .OrderBy(m => m.Title)
                                        .ToListAsync();
        }
    }
}
