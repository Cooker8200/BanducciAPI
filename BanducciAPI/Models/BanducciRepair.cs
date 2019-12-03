using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BanducciAPI.Models
{
    public class BanducciRepair
    {
        [Key]
        public int Id { get; set; }
        public int StoreNumber { get; set; }
        public DateTime ServiceDate { get; set; }
        public string Invoice { get; set; }
        public string Provider { get; set; }
        public string ServiceType { get; set; }
        public string Details { get; set; }
        public int Cost { get; set; }
        public int Paid { get; set; }
    }
}
