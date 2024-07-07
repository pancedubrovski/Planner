using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Planer.Models;
using Planer.Models.Commands;
using Planer.Models.Enums;
using Planer.Models.Queries;
using Planer.Repositories;
using Planer.Repositories.Interfaces;

namespace Planer.Controllers
{
    [Route("v1/planner/incomes")]
    [ApiController]
    public class IncomeControler : ControllerBase
    {

        private readonly IIncomeRepository _incomeRepository;
        public IncomeControler(IIncomeRepository incomeRepository) {
            _incomeRepository = incomeRepository;        
        }

        [HttpPost]
        public async Task<IActionResult> SaveIncome([FromBody] Command command)
        {
            await _incomeRepository.SaveIncome(command);
            return StatusCode(201);
        }

        [HttpGet]
        public async Task<IActionResult> GetIncomes()
        {
            var list = await _incomeRepository.GetIncomes();
            
            return Ok(list);
        }


       

        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> UpdateIncome([FromRoute] int id, [FromBody] UpdateCommand updateCommand)
        {
            var res = await _incomeRepository.UpdateIncome(id, updateCommand);
            return Ok(res);
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteIncome([FromRoute] int id)
        {
            var res = await _incomeRepository.DeleteElement(id);
            return Ok(res);
        }
    } 
}
