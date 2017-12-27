using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Models
{
    public class Promotion
    {
        public int PromotionId { get; set; }
        public string Description { get; set; }
        public int DiscountId { get; set; }
        public virtual Discount Discount { get; set; }
    }
}
