using System.Threading;
using System.Threading.Tasks;
using MediatR;
using movie_core.Requests;

namespace movie_core.RequestHandlers
{
    public class GetNowPlayingMoviesRequestHandler : IRequestHandler<GetNowPlayingMoviesRequest, MovieResultsDto>
    {
        private readonly IMovieHttpClient _movieHttpClient;

        public GetNowPlayingMoviesRequestHandler(IMovieHttpClient movieHttpClient)
        {
            _movieHttpClient = movieHttpClient;
        }
        
        public async Task<MovieResultsDto> Handle(GetNowPlayingMoviesRequest request, CancellationToken cancellationToken)
        {
            return await _movieHttpClient.GetNowPlayingMovies(request.ApiKey);
        }
    }
}