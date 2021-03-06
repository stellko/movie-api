using System.Collections.Generic;
using System.Threading;
using Moq;
using movie_core;
using movie_core.RequestHandlers;
using movie_core.Requests;
using Xunit;

namespace movie_test
{
    public class GetUpcomingMoviesTests
    {
        [Fact]
        public async void ReturnsOnePage()
        {
            //Arrange
            var movieHttpClientMock = new Mock<IMovieHttpClient>();
            movieHttpClientMock.Setup(client => client.GetUpcomingMovies())
                .ReturnsAsync(new MovieResultsDto {Page = 1, Results = new List<MovieDto>
                {
                    new MovieDto
                    {
                        OriginalTitle = "Gone Girl"
                    }
                }});

            var handler = new GetUpcomingMoviesRequestHandler(movieHttpClientMock.Object);

            //Act
            var result = await handler.Handle(new GetUpcomingMoviesRequest(), new CancellationToken());

            //Assert
            Assert.Equal(1, result.Page);
        }
    }
}