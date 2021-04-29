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
        public async Task<MovieResultsDto> GetTopRatedMovies(string apiKey = "54e106ed5ac2697be6cdc22a76b0d044")
        {
            _logger.LogInformation("Getting top rated movies");
            return await _mediator.Send(new GetTopRatedMoviesRequest {ApiKey = apiKey});
        }
        
        [HttpGet("upcoming")]
        public async Task<MovieResultsDto> GetUpcomingMovies(string apiKey = "54e106ed5ac2697be6cdc22a76b0d044")
        {
            _logger.LogInformation("Getting upcoming movies");
            return await _mediator.Send(new GetUpcomingMoviesRequest {ApiKey = apiKey});
        }
        
        [HttpGet("nowplaying")]
        public async Task<MovieResultsDto> GetNowPlayingMovies(string apiKey = "54e106ed5ac2697be6cdc22a76b0d044")
        {
            _logger.LogInformation("Getting now playing movies");
            return await _mediator.Send(new GetNowPlayingMoviesRequest {ApiKey = apiKey});
        }
    }
}