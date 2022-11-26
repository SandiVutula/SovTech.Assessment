using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SovTech.Models;
using SovTech.Services.Contract;

namespace SovTech.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        private readonly IJokeService _jokeService;

        #region Constructor 
        public JokesController(IJokeService jokeService) 
        {
            _jokeService = jokeService;
        }
        #endregion

        #region Endpoints
        [HttpGet]
        [Route("categories")]
        public async Task<string> GetCategories() 
        {
            return await _jokeService.GetCategories();
        }

        [HttpGet]
        [Route("random")]
        public async Task<string> GetRandomJokeByCategory(string category)
        {
            return await _jokeService.GetRandomJokeByCategory(category);
        }
        #endregion
    }

}
