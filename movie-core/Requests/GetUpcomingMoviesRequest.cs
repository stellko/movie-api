using MediatR;

namespace movie_core.Requests
{
    public class GetUpcomingMoviesRequest : IRequest<MovieResults>
    {
    }
}