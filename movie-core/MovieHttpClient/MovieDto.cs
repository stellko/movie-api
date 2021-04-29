using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace movie_core
{
    public class MovieResultsDto
    {
        [JsonPropertyName("page")] public int Page { get; set; }
        [JsonPropertyName("results")] public IEnumerable<MovieDto> Results { get; set; }

        public MovieResults ToMovieResults()
        {
            return new MovieResults
            {
                Page = Page,
                Movies = Results.Select(r => new Movie {OriginalTitle = r.OriginalTitle})
            };
        }
    }

    public class MovieDto
    {
        [JsonPropertyName("original_title")] public string OriginalTitle { get; set; }
    }
}