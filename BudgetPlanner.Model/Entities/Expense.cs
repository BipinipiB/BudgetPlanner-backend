using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Model.Entity
{
    public class Expense
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public float Amount { get; set; }

        public DateTime SpentOn { get; set; }
    }

}
