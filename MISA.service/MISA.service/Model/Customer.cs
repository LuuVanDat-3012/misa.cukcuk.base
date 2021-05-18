using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.service.Model
{
    public class Customer 
    {

        public Guid CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string  Fullname { get; set; }
        public int Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string Phone { get; set; }
        public string  Email { get; set; }
        public Guid CustomerGroupId { get; set; }
        public string Status { get; set; }
        public string MemberCardCode { get; set; }
        public string TaxCode { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }
        public string CustomerGroupName { get; set; }

        //      CustomerId char (36) NOT NULL DEFAULT '',
        //CustomerCode varchar(55) DEFAULT NULL,
        //Fullname varchar(255) DEFAULT NULL,
        //Gender int DEFAULT NULL,
        //Birthday datetime DEFAULT NULL,
        //Phone varchar(20) DEFAULT NULL,
        //Email varchar(100) DEFAULT NULL,
        //CustomerGroupId char (36) DEFAULT NULL,
        // Status varchar(255) DEFAULT NULL,
        // CreatedBy varchar(255) DEFAULT NULL,
        // CreatedDate datetime DEFAULT NULL,
        //ModifiedBy varchar(255) DEFAULT NULL,
        //ModifiedDate datetime DEFAULT NULL,
        //TaxCode varchar(255) DEFAULT NULL,
        //MemberCardCode varchar(255) DEFAULT NULL,
    }
 
}
