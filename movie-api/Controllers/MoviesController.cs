using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using movie_core;
using movie_core.Requests;

namespace movie_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IMediator _mediator;

        public MoviesController(ILogger<MoviesController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("toprated")]
        public async Task<MovieResults> GetTopRatedMovies()
        {
            _logger.LogInformation("Getting top rated movies");
            return await _mediator.Send(new GetTopRatedMoviesRequest());
        }
        
        [HttpGet("upcoming")]
        public async Task<MovieResults> GetUpcomingMovies()
        {
            _logger.LogInformation("Getting upcoming movies");
            return await _mediator.Send(new GetUpcomingMoviesRequest());
        }
        
        [HttpGet("nowplaying")]
        public async Task<MovieResults> GetNowPlayingMovies()
        {
            _logger.LogInformation("Getting now playing movies");
            return await _mediator.Send(new GetNowPlayingMoviesRequest());
        }
    }
}