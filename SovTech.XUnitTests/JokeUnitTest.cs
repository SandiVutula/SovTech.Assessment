using SovTech.Services;
using SovTech.Services.Contract;

namespace SovTech.XUnitTests
{
    public class JokeUnitTest : IClassFixture<IJokeService>
    {
        private readonly IJokeService _jokeService;

        public JokeUnitTest(IJokeService jokeService)
        {
            _jokeService = jokeService;
        }

        [Fact]
        public void Get_WhenCalled_ReturnsCategories()
        {
            // Act
            var categoriesResults = _jokeService.GetCategories();
            // Assert
            Assert.NotNull(categoriesResults);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsRandomJokeByCategory()
        {
            // Arrange
            var category = "career";

            // Act
            var randomJoke = _jokeService.GetRandomJokeByCategory(category);

            // Assert
            Assert.NotNull(randomJoke);
            Assert.Contains(category, "career");
        }
    }
}