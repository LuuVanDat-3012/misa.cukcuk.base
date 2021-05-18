using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.service.Model
{
    public class Enumeration
    {
        public enum MISAcode
        {
            Success = 200,
            Exception = 1000,
            error = 500,
            validate = 400
        }
    }
}
