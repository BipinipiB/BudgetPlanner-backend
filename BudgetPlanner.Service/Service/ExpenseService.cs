using BudgetPlanner.DataAccess.Repository;
using BudgetPlanner.Model.Entity;
using BudgetPlanner.Models.DTOs;
using BudgetPlanner.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Service.Service
{
    public class ExpenseService: IExpenseService
    {

        public  IExpenseRepo _expenseRepo;


        public ExpenseService(IExpenseRepo expenseRepo)
        {

            _expenseRepo = expenseRepo;

        }

        public async Task<List<ExpenseDto>> GetAllExpenses()
        {

            List<Expense> expenses = await _expenseRepo.GetAllExpenses();

            List<ExpenseDto> expenseDTOs = expenses.Select(e => new ExpenseDto
            {
                id = e.Id,
                Expensename = e.Name,
                Amount = e.Amount,
                SpentOn = e.SpentOn
            }).ToList();

            return expenseDTOs;

        }


        public async Task AddExpense(ExpenseDto expenseDto)
        {

            if(expenseDto.Expensename == ""){
                    new Exception("Expense name required");
            }
            else if (expenseDto.Amount == null )
            {
                new Exception("Amount required");
            }
            else if (expenseDto.SpentOn == null)
            {
                expenseDto.SpentOn = DateTime.Now;
            }
            else
            {
                Expense expense = new Expense()
                {
                    Amount = expenseDto.Amount,
                    Name = expenseDto.Expensename,
                    SpentOn = expenseDto.SpentOn
                };

                await _expenseRepo.AddExpense(expense);
            }

        }

        public async Task DeleteExpense(int id) {

            if (id == 0)
            {
                new Exception("Id required");
            }

            await _expenseRepo.DeleteExpense(id);
        
        }

        public async Task UpdateExpense(ExpenseDto expenseDto)
        {

            if (expenseDto.id == 0 || expenseDto.id == null) { 
            
                new Exception("Id cannot be 0 or null");

            }

            Expense expense = new Expense() { 
            
                Name = expenseDto.Expensename,
                Amount = expenseDto.Amount,
                SpentOn = expenseDto.SpentOn,
                Id= expenseDto.id
            };

            await _expenseRepo.UpdateExpense(expense);

        }
    }
}
