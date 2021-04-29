using System.Collections.Generic;

namespace movie_core
{
    public class MovieResults
    {
        public int Page { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }
    
    public class Movie
    {
        public string OriginalTitle { get; set; }
    }
}