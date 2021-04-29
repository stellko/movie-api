using System.Threading;
using System.Threading.Tasks;
using MediatR;
using movie_core.Requests;

namespace movie_core.RequestHandlers
{
    public class GetUpcomingMoviesRequestHandler : IRequestHandler<GetUpcomingMoviesRequest, MovieResultsDto>
    {
        private readonly IMovieHttpClient _movieHttpClient;

        public GetUpcomingMoviesRequestHandler(IMovieHttpClient movieHttpClient)
        {
            _movieHttpClient = movieHttpClient;
        }
        
        public async Task<MovieResultsDto> Handle(GetUpcomingMoviesRequest request, CancellationToken cancellationToken)
        {
            return await _movieHttpClient.GetUpcomingMovies(request.ApiKey);
        }
    }
}