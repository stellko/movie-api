using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Moq;
using movie_core;
using movie_core.RequestHandlers;
using movie_core.Requests;
using Xunit;

namespace movie_test
{
    public class GetTopRatedMoviesTests
    {
        [Fact]
        public async void ReturnsGoneGirl()
        {
            //Arrange
            var movieHttpClientMock = new Mock<IMovieHttpClient>();
            movieHttpClientMock.Setup(client => client.GetTopRatedMovies())
                .ReturnsAsync(new MovieResultsDto {Page = 1, Results = new List<MovieDto>
                {
                    new MovieDto
                    {
                        OriginalTitle = "Gone Girl"
                    }
                }});
            
            var handler = new GetTopRatedMoviesRequestHandler(movieHttpClientMock.Object);

            //Act
            var result = await handler.Handle(new GetTopRatedMoviesRequest(), new CancellationToken());

            //Assert
            Assert.Equal("Gone Girl", result.Movies.First().OriginalTitle);
        }
    }
}