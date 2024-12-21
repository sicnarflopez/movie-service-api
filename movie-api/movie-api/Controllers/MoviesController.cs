using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using movies_api.Logic.Interfaces;

namespace movie_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly string _apiKey;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovie(string? title)
        {
            var movies = await _movieService.GetMoviesAsync(title);
            return Ok(movies);
        }
    }
}
