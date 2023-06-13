using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_module2
{
    public class SomeException
    {
        public void WriteExcepion()
        {
            try
            {
                GetExcepion();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                FileService.WriteToFile(ex.ToString());
                Logger log = Logger.Instance;
                log.Log("Action failed by reason", Logger.LogLevel.Error);
            }
        }

        public void WriteBusinessExcepion()
        {
            try
            {
                GetBusinessExcepion();
            }
            catch (BusinessException ex)
            {
                Console.WriteLine(ex);
                FileService.WriteToFile(ex.ToString());
                Logger log = Logger.Instance;
                log.Log("Action got this custom Exception :”", Logger.LogLevel.Warning);
            }
        }

        private void GetBusinessExcepion()
        {
            throw new BusinessException("Skipped logic in method");
        }

        private void GetExcepion()
        {
            throw new Exception("I broke a logic");
        }
    }
}
