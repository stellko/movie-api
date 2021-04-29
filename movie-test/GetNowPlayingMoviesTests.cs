using System.Collections.Generic;
using System.Threading;
using Moq;
using movie_core;
using movie_core.RequestHandlers;
using movie_core.Requests;
using Xunit;

namespace movie_test
{
    public class GetNowPlayingMoviesTests
    {
        [Fact]
        public async void NoMoviesPlayingTest()
        {
            //Arrange
            var movieHttpClientMock = new Mock<IMovieHttpClient>();
            movieHttpClientMock.Setup(client => client.GetNowPlayingMovies(It.IsAny<string>()))
                .ReturnsAsync(new MovieResultsDto {page = 1, results = new List<MovieDto>()});

            var handler = new GetNowPlayingMoviesRequestHandler(movieHttpClientMock.Object);

            //Act
            var result = await handler.Handle(new GetNowPlayingMoviesRequest(), new CancellationToken());

            //Assert
            Assert.Empty(result.results);
        }
    }
}