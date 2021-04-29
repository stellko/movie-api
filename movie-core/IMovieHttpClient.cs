using System.Threading.Tasks;

namespace movie_core
{
    public interface IMovieHttpClient
    {
        Task<MovieResultsDto> GetTopRatedMovies(string apiKey);
        Task<MovieResultsDto> GetUpcomingMovies(string apiKey);
        Task<MovieResultsDto> GetNowPlayingMovies(string apiKey);
    }
}