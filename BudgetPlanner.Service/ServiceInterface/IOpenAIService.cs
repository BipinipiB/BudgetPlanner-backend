using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Service.ServiceInterface
{
    public  interface IOpenAIService
    {

        Task<string> AskAIForCategory(string expenseName);
    }
}
