using System.Threading;
using System.Threading.Tasks;
using MediatR;
using movie_core.Requests;

namespace movie_core.RequestHandlers
{
    public class GetTopRatedMoviesRequestHandler : IRequestHandler<GetTopRatedMoviesRequest, MovieResults>
    {
        private readonly IMovieHttpClient _movieHttpClient;

        public GetTopRatedMoviesRequestHandler(IMovieHttpClient movieHttpClient)
        {
            _movieHttpClient = movieHttpClient;
        }

        public async Task<MovieResults> Handle(GetTopRatedMoviesRequest request, CancellationToken cancellationToken)
        {
            var topRatedMovies = await _movieHttpClient.GetTopRatedMovies();
            return topRatedMovies.ToMovieResults();
        }
    }
}