using MediatR;

namespace movie_core.Requests
{
    public class GetTopRatedMoviesRequest : IRequest<MovieResultsDto>
    {
        public string ApiKey { get; set; }
    }
}