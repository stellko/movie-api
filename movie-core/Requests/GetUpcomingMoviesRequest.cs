using MediatR;

namespace movie_core.Requests
{
    public class GetUpcomingMoviesRequest : IRequest<MovieResultsDto>
    {
        public string ApiKey { get; set; }
    }
}