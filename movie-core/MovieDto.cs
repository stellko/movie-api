using System.Collections;
using System.Collections.Generic;

namespace movie_core
{
    public class MovieResultsDto
    {
        public int page { get; set; }
        public IEnumerable<MovieDto> results { get; set; }
    }
    public class MovieDto
    {
        public string original_title { get; set; }
    }
}