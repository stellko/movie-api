using MediatR;

namespace movie_core.Requests
{
    public class GetNowPlayingMoviesRequest : IRequest<MovieResults>
    {
    }
}