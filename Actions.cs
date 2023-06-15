using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HW5_module2
{
    public class Actions
    {
        public static Result First()
        {
            Logger log = Logger.Instance;
            log.Log("Start method:First", Logger.LogLevel.Info);
            return new Result(true, "Action failed by а reason:Result");
        }

        public static void Second()
        {
            throw new Exception("I broke a logic");
        }

        public static void Third()
        {
            throw new BusinessException("Skipped logic in method");
        }
    }
}
