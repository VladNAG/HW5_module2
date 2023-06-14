using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HW5_module2
{
    public static class Starter
    {
        public static void Run()
        {
            Random random = new Random();

            for (int i = 0; i < 101; i++)
            {
                int methodNumber = random.Next(1, 4);

                switch (methodNumber)
                {
                    case 1:
                        var result = Actions.First();
                        HandleResult(result);
                        break;
                    case 2:
                        try
                        {
                            Actions.Second();
                        }
                        catch (Exception ex)
                        {
                            Logger log = Logger.Instance;
                            log.Log("Action failed by reason", Logger.LogLevel.Error, ex);
                        }

                        break;
                    case 3:
                        try
                        {
                            Actions.Third();
                        }
                        catch (BusinessException ex)
                        {
                            Logger log = Logger.Instance;
                            log.Log("Action got this custom Exception :”", Logger.LogLevel.Warning, ex);
                        }

                        break;
                }
            }
        }

        public static void HandleResult(Result result)
        {
            if (!result.Status)
            {
                Logger log = Logger.Instance;
                log.Log(result.ErrorMessage, Logger.LogLevel.Error);
            }
        }
    }
}
