using Microsoft.EntityFrameworkCore;
using movies_api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movies_api.Data.Context
{
    public interface IMovieDbContext
    {
        DbSet<Movie> Movies { get; set; }
        Task<int> SaveChanges();
    }
}
