using BudgetPlanner.DataAccess.Repository;
using BudgetPlanner.Model.Entity;
using BudgetPlanner.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace BudgetPlanner.DataAccess
{
    public class ExpenseRepo : IExpenseRepo
    {

        public static ApplicationDBContext _dbContext;
        public ExpenseRepo(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddExpense(Expense expense)
        {
            await _dbContext.Expenses.AddAsync(expense);
    
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteExpense(int id)
        {
            var expenseToDelete = await _dbContext.Expenses.FirstOrDefaultAsync(e => e.Id == id);

            if (expenseToDelete != null)
            {
                _dbContext.Expenses.Remove(expenseToDelete);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                new Exception("Expense to delete not found");
            }
        }

        public async Task<List<Expense>> GetAllExpenses()
        {

            return await _dbContext.Expenses.ToListAsync();

        }

        public async Task UpdateExpense(Expense expense)
        {

            var result = await _dbContext.Expenses.FirstOrDefaultAsync(e=> e.Id == expense.Id);

        

            if (result!=null)
            {

                result.Amount = expense.Amount;
                result.SpentOn = expense.SpentOn;
                result.Name = expense.Name;
                _dbContext.Expenses.Update(result);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                new Exception("Expense to Update not found");
            }
        }
    }
}
