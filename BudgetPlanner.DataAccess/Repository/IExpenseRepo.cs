using BudgetPlanner.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.DataAccess.Repository
{
    public interface IExpenseRepo
    {

         Task<List<Expense>> GetAllExpenses();
         Task  AddExpense(Expense expense);
         Task UpdateExpense(Expense expense);

         Task  DeleteExpense(int id);
    }
}
