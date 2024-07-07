using Microsoft.AspNetCore.Mvc;
using Planer.Models.Commands;
using Planer.Models;
using Planer.Repositories.Interfaces;
using Planer.Repositories;

namespace Planer.Controllers
{
    [Route("v1/planner/expenses")]
    [ApiController]
    public class ExpnesesContoller : ControllerBase
    {

        private readonly IExpenseRepository _expenseRepository;
        public ExpnesesContoller(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Command command)
        {
            await _expenseRepository.SaveExpense(command);
            return StatusCode(201);
        }

        [HttpGet]
        public async Task<IActionResult> GetExpneses()
        {
            var list = await _expenseRepository.GetExpneses();
            return Ok(list);
        }


       

        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> UpdateExpenese([FromRoute] int id, [FromBody] UpdateCommand updateCommand)
        {
            var res = await _expenseRepository.UpdateExpenese(id, updateCommand);
            return Ok(res);
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var res = await _expenseRepository.DeleteElement(id);
            return Ok(res);
        }
    }
}
