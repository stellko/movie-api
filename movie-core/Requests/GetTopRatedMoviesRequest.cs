using MediatR;

namespace movie_core.Requests
{
    public class GetTopRatedMoviesRequest : IRequest<MovieResults>
    {
    }
}