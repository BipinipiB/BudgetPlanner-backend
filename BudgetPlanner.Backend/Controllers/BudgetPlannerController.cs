using BudgetPlanner.Models.DTOs;
using BudgetPlanner.Service.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace BudgetPlanner.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetPlannerController : ControllerBase
    {

        private static IExpenseService _expenseService;

        public BudgetPlannerController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet("GetExpenses")]
        public async Task<IActionResult> GetAllExpenses()
        {

            return Ok(await _expenseService.GetAllExpenses());
        }

        [HttpPost("AddExpenses")]
        public async Task<IActionResult> AddExpense(ExpenseDto expenseDto)
        {

            await _expenseService.AddExpense(expenseDto);
            return Ok();
        }

        [HttpPut("UpdateExpense")]

        public async Task<ActionResult> UpdateExpense(ExpenseDto updateObject)
        {
            await _expenseService.UpdateExpense(updateObject);
            return Ok();
        }

        [HttpDelete("DeleteExpense")]

        public async Task<IActionResult> DeleteExpense(int id)
        {
            await _expenseService.DeleteExpense(id);
            return Ok();
        }
    }
}
