using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Models
{
    public class Rental
    {
        public List<RentalDetail> RentalDetails { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }
        public int? PromotionId { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
    }
}
