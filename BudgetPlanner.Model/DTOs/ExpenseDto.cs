using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Models.DTOs
{
    public class ExpenseDto
    {

        public int id { get; set; }
        public string Expensename { get; set; }
        public float Amount { get; set; }

        public DateTime SpentOn { get; set; }
    }
}
