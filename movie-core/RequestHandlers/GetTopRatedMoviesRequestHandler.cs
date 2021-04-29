using System.Threading;
using System.Threading.Tasks;
using MediatR;
using movie_core.Requests;

namespace movie_core.RequestHandlers
{
    public class GetTopRatedMoviesRequestHandler : IRequestHandler<GetTopRatedMoviesRequest, MovieResultsDto>
    {
        private readonly IMovieHttpClient _movieHttpClient;

        public GetTopRatedMoviesRequestHandler(IMovieHttpClient movieHttpClient)
        {
            _movieHttpClient = movieHttpClient;
        }

        public async Task<MovieResultsDto> Handle(GetTopRatedMoviesRequest request, CancellationToken cancellationToken)
        {
            return await _movieHttpClient.GetTopRatedMovies(request.ApiKey);
        }
    }
}