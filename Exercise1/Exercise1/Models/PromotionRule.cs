using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Models
{
    public class PromotionRule
    {
        public int PromotionId { get; set; }
        public virtual Promotion Promotion { get; set; }
        public int RuleId { get; set; }
        public virtual Rule Rule { get; set; }
    }
}
