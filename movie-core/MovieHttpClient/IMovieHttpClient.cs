using System.Threading.Tasks;

namespace movie_core
{
    public interface IMovieHttpClient
    {
        Task<MovieResultsDto> GetTopRatedMovies();
        Task<MovieResultsDto> GetUpcomingMovies();
        Task<MovieResultsDto> GetNowPlayingMovies();
    }
}