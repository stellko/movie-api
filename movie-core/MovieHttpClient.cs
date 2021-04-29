using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace movie_core
{
    public class MovieHttpClient : IMovieHttpClient
    {
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;

        public MovieHttpClient(IConfiguration configuration)
        {
            _configuration = configuration;
            _baseUrl = _configuration["TheMovieDb:BaseUrl"];
        }
        
        public async Task<MovieResultsDto> GetTopRatedMovies(string apiKey)
        {
            var url = $"{_baseUrl}{_configuration["TheMovieDb:TopRated"]}?api_key={apiKey}";

            var json = await GetMovies(url);
            return JsonSerializer.Deserialize<MovieResultsDto>(json);
        }

        public async Task<MovieResultsDto> GetUpcomingMovies(string apiKey)
        {
            var url = $"{_baseUrl}{_configuration["TheMovieDb:Upcoming"]}?api_key={apiKey}";

            var json = await GetMovies(url);
            return JsonSerializer.Deserialize<MovieResultsDto>(json);
        }

        public async Task<MovieResultsDto> GetNowPlayingMovies(string apiKey)
        {
            var url = $"{_baseUrl}{_configuration["TheMovieDb:NowPlaying"]}?api_key={apiKey}";

            var json = await GetMovies(url);
            return JsonSerializer.Deserialize<MovieResultsDto>(json);
        }

        private async Task<string> GetMovies(string url)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}