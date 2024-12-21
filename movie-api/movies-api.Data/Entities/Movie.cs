using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movies_api.Data.Entities
{
    public class Movie
    {
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string PosterUrl { get; set; }
    }
}
