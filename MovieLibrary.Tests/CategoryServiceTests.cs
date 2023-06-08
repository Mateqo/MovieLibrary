using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieLibrary.Core.Models.Categories;
using MovieLibrary.Core.Services.Categories;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.Tests
{
    [TestClass]
    public class CategoryServiceTests
    {
        private Mock<IRepository<Category>> _categoryRepositoryMock;
        private ICategoryService _categoryService;

        [TestInitialize]
        public void Initialize()
        {
            _categoryRepositoryMock = new Mock<IRepository<Category>>();
            _categoryService = new CategoryService(_categoryRepositoryMock.Object);
        }

        [TestMethod]
        public async Task GetList_ReturnsListOfCategories()
        {
            // Arrange
            var categoryDtos = new List<Category>
            {
            new Category { Name = "category 1" },
            new Category { Name = "category 2" },
            new Category { Name = "category 3" }
            };

            _categoryRepositoryMock.Setup(repo => repo.GetList()).ReturnsAsync(categoryDtos);

            // Act
            var result = await _categoryService.GetList();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(categoryDtos.Count, result.Count());
        }

        [TestMethod]
        public async Task Update_UpdatesCategory()
        {
            // Arrange
            var categoryId = 4;
            var categoryUpdate = new CategoryUpdate { Name = "Updated name" };

            // Act
            await _categoryService.Update(categoryId, categoryUpdate);

            // Assert
            _categoryRepositoryMock.Verify(repo => repo.Update(It.Is<Category>(dto => dto.Id == categoryId && dto.Name == categoryUpdate.Name)), Times.Once);
        }

        [TestMethod]
        public async Task Delete_WhenCategoryExists()
        {
            // Arrange
            var categoryId = 4;
            _categoryRepositoryMock.Setup(repo => repo.Delete(categoryId)).ReturnsAsync(true);

            // Act
            var result = await _categoryService.Delete(categoryId);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task Delete_WhenCategoryNotExists()
        {
            // Arrange
            var categoryId = -99;
            _categoryRepositoryMock.Setup(repo => repo.Delete(categoryId)).ReturnsAsync(false);

            // Act
            var result = await _categoryService.Delete(categoryId);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
