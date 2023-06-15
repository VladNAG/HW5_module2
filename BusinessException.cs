using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HW5_module2
{
    [Serializable]
    public class BusinessException : Exception
    {
        public BusinessException(string maseg)
            : base(maseg)
        {
        }
    }
}
