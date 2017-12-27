using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Models
{
    public class RentalType
    {
        public int RentalTypeId { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public double PriceUnit { get; set; }
    }
}
