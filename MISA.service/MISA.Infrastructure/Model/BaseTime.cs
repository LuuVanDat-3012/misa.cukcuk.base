using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.service.Model
{
    public class BaseTime
    {
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }


        //      CreatedDate datetime DEFAULT NULL,
        //CreatedBy varchar(255) DEFAULT NULL,
        //ModifiedDate datetime DEFAULT NULL,
        //ModifiedBy varchar(255) DEFAULT NULL,
    }
}
