using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieLibrary.Core.Models.Movies;
using MovieLibrary.Core.Services.Movies;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Repositories;
using MovieLibrary.Data.Repositories.Movies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieLibrary.Tests
{
    [TestClass]
    public class MovieServiceTests
    {
        private Mock<IRepository<Movie>> _movieBaseRepositoryMock;
        private Mock<IRepository<MovieCategory>> _movieCategoryBaseRepositoryMock;
        private Mock<IMovieRepository> _movieRepositoryMock;
        private MovieService _movieService;

        [TestInitialize]
        public void Setup()
        {
            _movieBaseRepositoryMock = new Mock<IRepository<Movie>>();
            _movieCategoryBaseRepositoryMock = new Mock<IRepository<MovieCategory>>();
            _movieRepositoryMock = new Mock<IMovieRepository>();
            _movieService = new MovieService(_movieBaseRepositoryMock.Object, _movieRepositoryMock.Object, _movieCategoryBaseRepositoryMock.Object);
        }

        [TestMethod]
        public async Task Delete_WithValidId()
        {
            // Arrange
            var movieId = 1;
            var movieDto = new Movie { 
                Id = 1,
                Title = "Test",
                Description = "Description",
                Year = 2021,
                ImdbRating = 3,
                MovieCategories = new List<MovieCategory> { new MovieCategory { Id = 1 } }
            };
            _movieRepositoryMock.Setup(repo => repo.Get(movieId)).ReturnsAsync(movieDto);
            _movieBaseRepositoryMock.Setup(repo => repo.Delete(movieId)).ReturnsAsync(true);

            // Act
            var result = await _movieService.Delete(movieId);

            // Assert
            Assert.IsTrue(result);
            _movieBaseRepositoryMock.Verify(repo => repo.Delete(movieId), Times.Exactly(1));
        }


        [TestMethod]
        public async Task Update_Category()
        {
            // Arrange
            var movieId = 1;
            var movieUpdate = new MovieUpdate
            {
                Title = "Test",
                Description = "Description",
                Year = 2022,
                ImdbRating = 3
            };

            var existingMovie = new Movie
            {
                Id = 1,
                Title = "Test",
                Description = "Description",
                Year = 2021,
                ImdbRating = 4
            };

            _movieRepositoryMock.Setup(repo => repo.Get(movieId)).ReturnsAsync(existingMovie);

            // Act
            await _movieService.Update(movieId, movieUpdate);

            // Assert
            _movieBaseRepositoryMock.Verify(repo => repo.Update(It.Is<Movie>(m => m.Id == movieId &&
            m.Year == movieUpdate.Year &&
            m.ImdbRating == movieUpdate.ImdbRating)), Times.Once);
        }
    }
}
