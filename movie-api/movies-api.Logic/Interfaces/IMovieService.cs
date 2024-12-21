using movies_api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movies_api.Logic.Interfaces
{
    public interface IMovieService
    {
        Task<List<Movie>> GetMoviesAsync(string title);
    }
}
