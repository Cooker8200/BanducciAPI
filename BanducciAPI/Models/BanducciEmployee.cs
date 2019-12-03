using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BanducciAPI.Models
{
    public class BanducciEmployee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? TermDate { get; set; }
        public string Position { get; set; }
        public int StoreLocation { get; set; }
    }
}
