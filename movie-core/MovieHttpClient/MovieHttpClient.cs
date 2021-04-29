using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace movie_core
{
    public class MovieHttpClient : IMovieHttpClient
    {
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl = "https://api.themoviedb.org/3/movie/";
        private readonly string _apiKey;

        public MovieHttpClient(IConfiguration configuration)
        {
            _configuration = configuration;
            _apiKey = configuration["TheMovieDb:ApiKey"];
        }
        
        public async Task<MovieResultsDto> GetTopRatedMovies()
        {
            var url = $"{_baseUrl}top_rated?api_key={_apiKey}";

            var json = await GetMovies(url);
            return JsonSerializer.Deserialize<MovieResultsDto>(json);
        }

        public async Task<MovieResultsDto> GetUpcomingMovies()
        {
            var url = $"{_baseUrl}upcoming?api_key={_apiKey}";

            var json = await GetMovies(url);
            return JsonSerializer.Deserialize<MovieResultsDto>(json);
        }

        public async Task<MovieResultsDto> GetNowPlayingMovies()
        {
            var url = $"{_baseUrl}now_playing?api_key={_apiKey}";

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