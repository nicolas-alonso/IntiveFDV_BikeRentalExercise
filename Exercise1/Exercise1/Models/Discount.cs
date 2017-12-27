using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exercise1.Helpers.Constants;

namespace Exercise1.Models
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public string DiscountType { get; set; }
        public double Amount { get; set; }
    }
}
