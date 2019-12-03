using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BanducciAPI.Models
{
    public class BanducciServSafe
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? TestDate { get; set; }
        public string CertificateNumber { get; set; }
        public DateTime? Expiration { get; set; }
        public string Proctor { get; set; }
    }
}
