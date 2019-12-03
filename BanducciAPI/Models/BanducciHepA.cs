using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BanducciAPI.Models
{
    public class BanducciHepA
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastNAme { get; set; }
        public DateTime? FirstShot { get; set; }
        public DateTime? SecondShot { get; set; }
    }
}
