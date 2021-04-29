using System.Threading;
using System.Threading.Tasks;
using MediatR;
using movie_core.Requests;

namespace movie_core.RequestHandlers
{
    public class GetUpcomingMoviesRequestHandler : IRequestHandler<GetUpcomingMoviesRequest, MovieResults>
    {
        private readonly IMovieHttpClient _movieHttpClient;

        public GetUpcomingMoviesRequestHandler(IMovieHttpClient movieHttpClient)
        {
            _movieHttpClient = movieHttpClient;
        }
        
        public async Task<MovieResults> Handle(GetUpcomingMoviesRequest request, CancellationToken cancellationToken)
        {
            var upcomingMovies = await _movieHttpClient.GetUpcomingMovies();
            return upcomingMovies.ToMovieResults();
        }
    }
}