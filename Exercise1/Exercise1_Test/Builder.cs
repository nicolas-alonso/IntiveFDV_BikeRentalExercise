using Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exercise1.Helpers.Constants;

namespace Exercise1_Test
{
    public static class Builder
    {
        /*Builder creator functions*/
        public static Bike CreateBike(TestContext ctx, int bikeId, string description)
        {
            Bike bike = new Bike();
            bike.BikeId = bikeId;
            bike.Description = description;
            ctx.Bikes.Add(bike);
            return bike;
        }

        public static Client CreateClient(TestContext ctx, int clientId, string firstName, string lastName)
        {
            Client client = new Client();
            client.ClientId = clientId;
            client.FirstName = firstName;
            client.LastName  = lastName;
            return client;
        }

        public static Discount CreateDiscount(TestContext ctx, int discountId, string discountType, double amount)
        {
            Discount discount = new Discount();
            discount.DiscountId = discountId;
            discount.DiscountType = discountType;
            discount.Amount = amount;
            ctx.Discounts.Add(discount);
            return discount;
        }

        public static Promotion CreatePromotion(TestContext ctx, int promotionId, string description, int discountId)
        {
            Promotion promotion = new Promotion();
            promotion.PromotionId = promotionId;
            promotion.Description = description;
            promotion.DiscountId = discountId;
            promotion.Discount = ctx.Discounts.Where(x => x.DiscountId == discountId).FirstOrDefault();
            ctx.Promotions.Add(promotion);
            return promotion;
        }

        public static PromotionRule CreatePromotionRule(TestContext ctx, int promotionId, int ruleId)
        {
            PromotionRule promotionRule = new PromotionRule();
            promotionRule.PromotionId = promotionId;
            promotionRule.Promotion = ctx.Promotions.Where(x => x.PromotionId == promotionId).FirstOrDefault();
            promotionRule.RuleId = ruleId;
            promotionRule.Rule = ctx.Rules.Where(x => x.RuleId == ruleId).FirstOrDefault();
            ctx.PromotionRules.Add(promotionRule);
            return promotionRule;
        }

        public static Rental CreateRental(TestContext ctx, List<RentalDetail> rentalDetails, string description, int clientId, int? promotionId, DateTime date, double total)
        {
            Rental rental = new Rental();
            rental.RentalDetails = rentalDetails;
            rental.Description = description;
            rental.ClientId = clientId;
            rental.PromotionId = promotionId;
            rental.Date = date;
            rental.Total = total;
            ctx.Rentals.Add(rental);
            return rental;
        }

        public static RentalDetail CreateRentalDetail(TestContext ctx, int bikeId, int rentalId, int rentalTypeId, DateTime startDate, DateTime endDate, int numberOfUnits)
        {
            RentalDetail rentalDetail = new RentalDetail();
            rentalDetail.BikeId = bikeId;
            rentalDetail.RentalId = rentalId;
            rentalDetail.RentalTypeId = rentalTypeId;
            rentalDetail.RentalType = ctx.RentalTypes.Where(x => x.RentalTypeId == rentalTypeId).FirstOrDefault();
            rentalDetail.StartDate = startDate;
            rentalDetail.EndDate = endDate;
            rentalDetail.NumberOfUnits = numberOfUnits;
            ctx.RentalDetails.Add(rentalDetail);
            return rentalDetail;
        }

        public static RentalType CreateRentalType(TestContext ctx, int rentalTypeId, string description, string unit, double priceUnit)
        {
            RentalType rentalType = new RentalType();
            rentalType.RentalTypeId = rentalTypeId;
            rentalType.Description = description;
            rentalType.Unit = unit;
            rentalType.PriceUnit = priceUnit;
            ctx.RentalTypes.Add(rentalType);
            return rentalType;
        }

        public static Rule CreateRule(TestContext ctx, int ruleId, string description, string condition)
        {
            Rule rule = new Rule();
            rule.RuleId = ruleId;
            rule.Description = description;
            rule.Condition = condition;
            ctx.Rules.Add(rule);
            return rule;
        }

        /*Builder populate context functions*/
        public static void CreateDefaultContext(TestContext ctx)
        {
            CreateContextBikes(ctx);
            CreateContextClients(ctx);
            CreateContextDiscounts(ctx);
            CreateContextPromotions(ctx);
            CreateContextRules(ctx);
            CreateContextPromotionRules(ctx);
            CreateContextRentalTypes(ctx);
            CreateContextRentalDetails(ctx);
            CreateContextRentals(ctx);
        }

        public static List<Bike> CreateContextBikes(TestContext ctx)
        {
            List<Bike> bikes = new List<Bike>();
            return bikes;
        }

        public static List<Client> CreateContextClients(TestContext ctx)
        {
            List<Client> clients = new List<Client>();
            return clients;
        }

        public static List<Discount> CreateContextDiscounts(TestContext ctx)
        {
            List<Discount> discounts = new List<Discount>();
            discounts.Add(CreateDiscount(ctx, 1, DiscountTypes.Percentage, 0.3));
            return discounts;
        }

        public static List<Promotion> CreateContextPromotions(TestContext ctx)
        {
            List<Promotion> promotions = new List<Promotion>();
            promotions.Add(CreatePromotion(ctx, 1, "Family rental", 1));
            return promotions;
        }

        public static List<Rule> CreateContextRules(TestContext ctx)
        {
            List<Rule> rules = new List<Rule>();
            rules.Add(CreateRule(ctx, 1, "From 3 to 5 rentals(any type)", ConditionTypes.FamilyRental));
            return rules;
        }

        public static List<PromotionRule> CreateContextPromotionRules(TestContext ctx)
        {
            List<PromotionRule> promotionRules = new List<PromotionRule>();
            promotionRules.Add(CreatePromotionRule(ctx, 1, 1));
            return promotionRules;
        }

        public static List<RentalType> CreateContextRentalTypes(TestContext ctx) {
            List<RentalType> rentalTypes = new List<RentalType>();
            rentalTypes.Add(CreateRentalType(ctx, 1, "Rental by hour", RentalTypeUnits.Hour, 5));
            rentalTypes.Add(CreateRentalType(ctx, 2, "Rental by day", RentalTypeUnits.Day, 20));
            rentalTypes.Add(CreateRentalType(ctx, 3, "Rental by week", RentalTypeUnits.Week, 60));
            return rentalTypes;
        }

        public static List<RentalDetail> CreateContextRentalDetails(TestContext ctx)
        {
            List<RentalDetail> rentalDetails = new List<RentalDetail>();
            return rentalDetails;
        }

        public static List<Rental> CreateContextRentals(TestContext ctx)
        {
            List<Rental> rentals = new List<Rental>();
            return rentals;
        }
    }
}
