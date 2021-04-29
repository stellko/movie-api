using System.Threading;
using System.Threading.Tasks;
using MediatR;
using movie_core.Requests;

namespace movie_core.RequestHandlers
{
    public class GetNowPlayingMoviesRequestHandler : IRequestHandler<GetNowPlayingMoviesRequest, MovieResults>
    {
        private readonly IMovieHttpClient _movieHttpClient;

        public GetNowPlayingMoviesRequestHandler(IMovieHttpClient movieHttpClient)
        {
            _movieHttpClient = movieHttpClient;
        }
        
        public async Task<MovieResults> Handle(GetNowPlayingMoviesRequest request, CancellationToken cancellationToken)
        {
            var nowPlayingMovies = await _movieHttpClient.GetNowPlayingMovies();
            return nowPlayingMovies.ToMovieResults();
        }
    }
}