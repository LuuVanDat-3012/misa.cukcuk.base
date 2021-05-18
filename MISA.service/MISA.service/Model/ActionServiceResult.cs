using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MISA.service.Model.Enumeration;

namespace MISA.service.Model
{
    public class ActionServiceResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public MISAcode MISAcode { get; set; }
        public object data { get; set; }
    }
}
