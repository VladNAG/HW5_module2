using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_module2
{
    public class Result
    {
        public Result(bool status, string errorMessage)
        {
            Status = status;
            ErrorMessage = errorMessage;
        }

        public bool Status { get; }
        public string ErrorMessage { get; }
    }
}
