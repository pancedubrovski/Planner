using Microsoft.AspNetCore.Mvc;
using Planer.Models.Queries;
using Planer.Models;
using Planer.Repositories.Interfaces;
using Planer.Repositories;

namespace Planer.Controllers
{
    [ApiController]
    [Route("v1/planner/calculate")]
    public class CalcuationCaontroller : ControllerBase
    {
        private readonly ICalculationRepository _calculationRepository;
        public CalcuationCaontroller(ICalculationRepository calculationRepository)
        {
            _calculationRepository = calculationRepository;
        }

        [HttpPost]
        public async Task<IActionResult> GetBuget()
        {
            var res = await _calculationRepository.CalcuateBuget();
            return Ok(res);
        }
    }
}
