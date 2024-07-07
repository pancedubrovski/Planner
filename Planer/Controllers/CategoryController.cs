using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Planer.Models.Queries;
using Planer.Models;
using Planer.Repositories.Interfaces;
using Planer.Models.Enums;
using Microsoft.Extensions.Logging.Abstractions;
using System.Linq;

namespace Planer.Controllers
{
    [ApiController]
    [Route("v1/planner/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepositories;
        public CategoryController(ICategoryRepository categoryRepositories)
        {
            _categoryRepositories = categoryRepositories;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategory([FromQuery] CategoryQuery categoryQuery)
        {
            var  kinds = categoryQuery.Kinds.Split(",").ToList().Select(e => Enum.Parse(typeof(CategoryKind), e));
            var items = await _categoryRepositories.GetList<Category>((c) => 
            kinds.Contains(c.Kind), null);

            return Ok(items);
        }
    }
}
