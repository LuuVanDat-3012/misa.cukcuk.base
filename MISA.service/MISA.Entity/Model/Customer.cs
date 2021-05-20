using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Entity.Model
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string Fullname { get; set; }
        public int Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid CustomerGroupId { get; set; }
        public string GroupId { get; set; }
        public string Status { get; set; }
        public string MemberCardCode { get; set; }
        public string TaxCode { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }
}

}
