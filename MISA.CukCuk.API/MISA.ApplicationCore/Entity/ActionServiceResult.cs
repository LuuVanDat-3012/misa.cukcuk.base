using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MISA.ApplicationCore.Entity.Enumeration;

namespace MISA.ApplicationCore.Entity
{
    public class ActionServiceResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public MISAcode MISAcode { get; set; }
        public List<FieldNotValid> fieldNotValids { get; set; } = new List<FieldNotValid>();
        public object data { get; set; }
    }
}
