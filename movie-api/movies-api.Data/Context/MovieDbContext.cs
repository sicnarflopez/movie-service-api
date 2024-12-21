using Microsoft.EntityFrameworkCore;
using movies_api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movies_api.Data.Context
{
    public class MovieDbContext : DbContext, IMovieDbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public new async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
