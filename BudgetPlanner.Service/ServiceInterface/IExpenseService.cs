using BudgetPlanner.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Service.ServiceInterface
{
    public interface IExpenseService
    {

        Task<List<ExpenseDto>> GetAllExpenses();
        Task AddExpense(ExpenseDto expenseDto);

        Task DeleteExpense(int id);

        Task UpdateExpense(ExpenseDto expenseDto);
    }
}
