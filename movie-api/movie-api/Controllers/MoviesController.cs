using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace movie_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMovies(string title)
        {
            return Ok();
        }
    }
}
