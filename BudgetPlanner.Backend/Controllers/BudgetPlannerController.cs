using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace BudgetPlanner.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetPlannerController : ControllerBase
    {

        [HttpGet("GetExpenses")]
        public async Task<IActionResult> GetExpenses()
        {

            return Ok(await GetExpenses());
        }

        [HttpPost("AddExpenses")]
        public async Task<IActionResult> AddExpense()
        {
            return Ok();
        }

        [HttpPut("UpdateExpense")]

        public async Task<ActionResult> UpdateExpense()
        {
            return Ok();
        }

        [HttpDelete("DeleteExpense")]

        public async Task<IActionResult> DeleteExpense(int id)
        {
            return Ok();
        }
    }
}
