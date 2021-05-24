using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Entity.Model
{
    public class Enumeration
    {
        public enum MISAcode
        {
            Success = 200,
            Exception = 1000,
            Error = 500,
            Validate = 400,
            Howllow = 205
        }
    }
}
