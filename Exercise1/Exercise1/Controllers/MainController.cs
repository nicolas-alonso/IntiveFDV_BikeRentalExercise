using Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exercise1.Helpers.Constants;

namespace Exercise1.Controllers
{
    public class MainController
    {
        public Rental RentBikes(List<RentalDetail> rentalDetails, string description, Client client, Promotion promotion, List<PromotionRule> promotionRules)
        {
            Rental rental = new Rental();
            rental.RentalDetails = rentalDetails;
            rental.Description = description;
            rental.ClientId = client.ClientId;
            rental.Date = DateTime.Now;
            rental.Total = 0;
            foreach (var rentalDetail in rentalDetails)
            {
                rental.Total += rentalDetail.NumberOfUnits * rentalDetail.RentalType.PriceUnit;
            }
            if (promotion != null && promotionRules != null)
            {
                if (PromotionApplies(rental, promotionRules))
                {
                    rental.PromotionId = promotion.PromotionId;
                    rental.Total = ApplyDiscount(rental.Total, promotion.Discount);
                }
            }
            return rental;
        }

        private bool PromotionApplies(Rental rental, List<PromotionRule> promotionRules)
        {
            bool promotionApplies = false;
            foreach (var rule in promotionRules)
            {
                switch (rule.Rule.Condition)
                {
                    case ConditionTypes.FamilyRental:
                        promotionApplies = rental.RentalDetails.Count >= 3 && rental.RentalDetails.Count <= 5;
                        break;
                    default:
                        break;
                }
            }
            return promotionApplies;
        }

        private double ApplyDiscount(double total, Discount discount)
        {
            if (discount == null)
                return 0;
            double discountAmount = 0;
            switch (discount.DiscountType)
            {
                case DiscountTypes.Currency:
                    discountAmount = discount.Amount;
                    break;
                case DiscountTypes.Percentage:
                    discountAmount = discount.Amount * total;
                    break;
                default:
                    break;
            }
            return total - discountAmount;
        }
    }
}
