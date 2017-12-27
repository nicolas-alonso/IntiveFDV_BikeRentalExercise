using Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1_Test
{
    public class TestContext
    {
        public TestContext()
        {
            Bikes = new List<Bike>();
            Clients = new List<Client>();
            Discounts = new List<Discount>();
            Promotions = new List<Promotion>();
            PromotionRules = new List<PromotionRule>();
            Rentals = new List<Rental>();
            RentalDetails = new List<RentalDetail>();
            RentalTypes = new List<RentalType>();
            Rules = new List<Rule>();
        }

        public IList<Bike> Bikes { get; set; }
        public IList<Client> Clients { get; set; }
        public IList<Discount> Discounts { get; set; }
        public IList<Promotion> Promotions { get; set; }
        public IList<PromotionRule> PromotionRules { get; set; }
        public IList<Rental> Rentals { get; set; }
        public IList<RentalDetail> RentalDetails { get; set; }
        public IList<RentalType> RentalTypes { get; set; }
        public IList<Rule> Rules { get; set; }
    }
}
