using MediatR;

namespace movie_core.Requests
{
    public class GetNowPlayingMoviesRequest : IRequest<MovieResultsDto>
    {
        public string ApiKey { get; set; }
    }
}