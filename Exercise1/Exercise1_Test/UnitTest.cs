
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise1.Models;
using System.Collections.Generic;
using Exercise1.Controllers;
using System.Linq;
using static Exercise1.Helpers.Constants;

namespace Exercise1_Test
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext ctx;
        public MainController controller;

        [TestInitialize]
        public void TestInitialize()
        {
            ctx = new TestContext();
            controller = new MainController();
            Builder.CreateDefaultContext(ctx);
        }

        [TestMethod]
        public void RentBikeTest()
        {
            //Arrange
            var bike = Builder.CreateBike(ctx, 1, "First bike");
            var client = Builder.CreateClient(ctx, 1, "John", "Doe");
            var rentalDetail = Builder.CreateRentalDetail(ctx, bike.BikeId, 1, RentalTypeUnitCodes.Day, DateTime.Parse("2017-12-01"), DateTime.Parse("2017-12-05"), 4);
            var rentalDetails = new List<RentalDetail>();
            rentalDetails.Add(rentalDetail);

            //Act
            Rental rental = controller.RentBikes(rentalDetails, "First rental", client, null, null);

            //Assert
            Assert.AreEqual(bike.BikeId, rental.RentalDetails.Where(x => x.RentalId == rentalDetail.RentalId).FirstOrDefault().BikeId);
            Assert.AreEqual(client.ClientId, rental.ClientId);
            Assert.AreEqual(rentalDetail.StartDate, rental.RentalDetails.Where(x => x.RentalId == rentalDetail.RentalId && x.BikeId == rentalDetail.BikeId).FirstOrDefault().StartDate);
            Assert.AreEqual(rentalDetail.EndDate, rental.RentalDetails.Where(x => x.RentalId == rentalDetail.RentalId && x.BikeId == rentalDetail.BikeId).FirstOrDefault().EndDate);
            Assert.AreEqual(rentalDetail.NumberOfUnits * rentalDetail.RentalType.PriceUnit, rental.Total);
        }

        [TestMethod]
        public void RentSeveralBikesTest()
        {
            //Arrange
            var bike1 = Builder.CreateBike(ctx, 1, "First bike");
            var bike2 = Builder.CreateBike(ctx, 2, "Second bike");
            var bike3 = Builder.CreateBike(ctx, 3, "Third bike");
            var client = Builder.CreateClient(ctx, 1, "John", "Doe");
            var rentalDetail1 = Builder.CreateRentalDetail(ctx, bike1.BikeId, 1, RentalTypeUnitCodes.Day, DateTime.Parse("2017-12-01"), DateTime.Parse("2017-12-05"), 4);
            var rentalDetail2 = Builder.CreateRentalDetail(ctx, bike2.BikeId, 1, RentalTypeUnitCodes.Day, DateTime.Parse("2017-12-01"), DateTime.Parse("2017-12-05"), 4);
            var rentalDetail3 = Builder.CreateRentalDetail(ctx, bike3.BikeId, 1, RentalTypeUnitCodes.Day, DateTime.Parse("2017-12-01"), DateTime.Parse("2017-12-05"), 4);
            var rentalDetails = new List<RentalDetail>();
            rentalDetails.Add(rentalDetail1);
            rentalDetails.Add(rentalDetail2);
            rentalDetails.Add(rentalDetail3);

            //Act
            Rental rental = controller.RentBikes(rentalDetails, "Several bikes rental", client, null, null);

            //Assert
            Assert.AreEqual(bike1.BikeId, rental.RentalDetails.Where(x => x.BikeId == bike1.BikeId).FirstOrDefault().BikeId);
            Assert.AreEqual(bike2.BikeId, rental.RentalDetails.Where(x => x.BikeId == bike2.BikeId).FirstOrDefault().BikeId);
            Assert.AreEqual(bike3.BikeId, rental.RentalDetails.Where(x => x.BikeId == bike3.BikeId).FirstOrDefault().BikeId);
            Assert.AreEqual(client.ClientId, rental.ClientId);
            Assert.AreEqual(rentalDetail1.StartDate, rental.RentalDetails.Where(x => x.RentalId == rentalDetail1.RentalId && x.BikeId == rentalDetail1.BikeId).FirstOrDefault().StartDate);
            Assert.AreEqual(rentalDetail2.StartDate, rental.RentalDetails.Where(x => x.RentalId == rentalDetail2.RentalId && x.BikeId == rentalDetail2.BikeId).FirstOrDefault().StartDate);
            Assert.AreEqual(rentalDetail3.StartDate, rental.RentalDetails.Where(x => x.RentalId == rentalDetail3.RentalId && x.BikeId == rentalDetail3.BikeId).FirstOrDefault().StartDate);
            Assert.AreEqual(rentalDetail1.EndDate, rental.RentalDetails.Where(x => x.RentalId == rentalDetail1.RentalId && x.BikeId == rentalDetail1.BikeId).FirstOrDefault().EndDate);
            Assert.AreEqual(rentalDetail2.EndDate, rental.RentalDetails.Where(x => x.RentalId == rentalDetail2.RentalId && x.BikeId == rentalDetail2.BikeId).FirstOrDefault().EndDate);
            Assert.AreEqual(rentalDetail3.EndDate, rental.RentalDetails.Where(x => x.RentalId == rentalDetail3.RentalId && x.BikeId == rentalDetail3.BikeId).FirstOrDefault().EndDate);
            Assert.AreEqual(rentalDetail1.NumberOfUnits * rentalDetail1.RentalType.PriceUnit +
                rentalDetail2.NumberOfUnits * rentalDetail2.RentalType.PriceUnit +
                rentalDetail3.NumberOfUnits * rentalDetail3.RentalType.PriceUnit, rental.Total);
        }

        [TestMethod]
        public void RentSeveralBikesDifferentRentalTypesTest()
        {
            //Arrange
            var bike1 = Builder.CreateBike(ctx, 1, "First bike by hour");
            var bike2 = Builder.CreateBike(ctx, 2, "Second bike by day");
            var bike3 = Builder.CreateBike(ctx, 3, "Third bike by week");
            var client = Builder.CreateClient(ctx, 1, "John", "Doe");
            var rentalDetail1 = Builder.CreateRentalDetail(ctx, bike1.BikeId, 1, RentalTypeUnitCodes.Hour, DateTime.Parse("2017-12-01T09:00:00"), DateTime.Parse("2017-12-01T19:00:00"), 10);
            var rentalDetail2 = Builder.CreateRentalDetail(ctx, bike2.BikeId, 1, RentalTypeUnitCodes.Day, DateTime.Parse("2017-12-01"), DateTime.Parse("2017-12-03"), 2);
            var rentalDetail3 = Builder.CreateRentalDetail(ctx, bike3.BikeId, 1, RentalTypeUnitCodes.Week, DateTime.Parse("2017-12-01"), DateTime.Parse("2017-12-08"), 1);
            var rentalDetails = new List<RentalDetail>();
            rentalDetails.Add(rentalDetail1);
            rentalDetails.Add(rentalDetail2);
            rentalDetails.Add(rentalDetail3);

            //Act
            Rental rental = controller.RentBikes(rentalDetails, "Several bikes different rental types", client, null, null);

            //Assert
            Assert.AreEqual(bike1.BikeId, rental.RentalDetails.Where(x => x.BikeId == bike1.BikeId).FirstOrDefault().BikeId);
            Assert.AreEqual(bike2.BikeId, rental.RentalDetails.Where(x => x.BikeId == bike2.BikeId).FirstOrDefault().BikeId);
            Assert.AreEqual(bike3.BikeId, rental.RentalDetails.Where(x => x.BikeId == bike3.BikeId).FirstOrDefault().BikeId);
            Assert.AreEqual(client.ClientId, rental.ClientId);
            Assert.AreEqual(rentalDetail1.StartDate, rental.RentalDetails.Where(x => x.RentalId == rentalDetail1.RentalId && x.BikeId == rentalDetail1.BikeId).FirstOrDefault().StartDate);
            Assert.AreEqual(rentalDetail2.StartDate, rental.RentalDetails.Where(x => x.RentalId == rentalDetail2.RentalId && x.BikeId == rentalDetail2.BikeId).FirstOrDefault().StartDate);
            Assert.AreEqual(rentalDetail3.StartDate, rental.RentalDetails.Where(x => x.RentalId == rentalDetail3.RentalId && x.BikeId == rentalDetail3.BikeId).FirstOrDefault().StartDate);
            Assert.AreEqual(rentalDetail1.EndDate, rental.RentalDetails.Where(x => x.RentalId == rentalDetail1.RentalId && x.BikeId == rentalDetail1.BikeId).FirstOrDefault().EndDate);
            Assert.AreEqual(rentalDetail2.EndDate, rental.RentalDetails.Where(x => x.RentalId == rentalDetail2.RentalId && x.BikeId == rentalDetail2.BikeId).FirstOrDefault().EndDate);
            Assert.AreEqual(rentalDetail3.EndDate, rental.RentalDetails.Where(x => x.RentalId == rentalDetail3.RentalId && x.BikeId == rentalDetail3.BikeId).FirstOrDefault().EndDate);
            Assert.AreEqual(rentalDetail1.NumberOfUnits * rentalDetail1.RentalType.PriceUnit +
                rentalDetail2.NumberOfUnits * rentalDetail2.RentalType.PriceUnit +
                rentalDetail3.NumberOfUnits * rentalDetail3.RentalType.PriceUnit, rental.Total);
        }

        [TestMethod]
        public void FamilyRentalPromotionAppliedTest()
        {
            //Arrange
            var bike1 = Builder.CreateBike(ctx, 1, "First bike by hour");
            var bike2 = Builder.CreateBike(ctx, 2, "Second bike by day");
            var bike3 = Builder.CreateBike(ctx, 3, "Third bike by week");
            var client = Builder.CreateClient(ctx, 1, "John", "Doe");
            var rentalDetail1 = Builder.CreateRentalDetail(ctx, bike1.BikeId, 1, RentalTypeUnitCodes.Hour, DateTime.Parse("2017-12-01T09:00:00"), DateTime.Parse("2017-12-01T19:00:00"), 10);
            var rentalDetail2 = Builder.CreateRentalDetail(ctx, bike2.BikeId, 1, RentalTypeUnitCodes.Day, DateTime.Parse("2017-12-01"), DateTime.Parse("2017-12-03"), 2);
            var rentalDetail3 = Builder.CreateRentalDetail(ctx, bike3.BikeId, 1, RentalTypeUnitCodes.Week, DateTime.Parse("2017-12-01"), DateTime.Parse("2017-12-08"), 1);
            var rentalDetails = new List<RentalDetail>();
            rentalDetails.Add(rentalDetail1);
            rentalDetails.Add(rentalDetail2);
            rentalDetails.Add(rentalDetail3);
            var promotion = ctx.Promotions.Where(x => x.PromotionId == 1).FirstOrDefault();
            var promotionRules = ctx.PromotionRules.ToList();

            //Act
            Rental rental = controller.RentBikes(rentalDetails, "Several bikes different rental types", client, promotion, promotionRules);

            //Assert
            var subTotal = rentalDetail1.NumberOfUnits * rentalDetail1.RentalType.PriceUnit +
                rentalDetail2.NumberOfUnits * rentalDetail2.RentalType.PriceUnit +
                rentalDetail3.NumberOfUnits * rentalDetail3.RentalType.PriceUnit;
            var total = subTotal - (subTotal * promotion.Discount.Amount);
            Assert.AreEqual(total, rental.Total);
        }

        [TestMethod]
        public void FamilyRentalPromotionNotAppliedTest()
        {
            //Arrange
            var bike1 = Builder.CreateBike(ctx, 1, "First bike by hour");
            var bike2 = Builder.CreateBike(ctx, 2, "Second bike by day");
            var bike3 = Builder.CreateBike(ctx, 3, "Third bike by week");
            var bike4 = Builder.CreateBike(ctx, 4, "Forth bike by week");
            var bike5 = Builder.CreateBike(ctx, 5, "Fifth bike by week");
            var bike6 = Builder.CreateBike(ctx, 6, "Sixth bike by week");
            var client = Builder.CreateClient(ctx, 1, "John", "Doe");
            var rentalDetail1 = Builder.CreateRentalDetail(ctx, bike1.BikeId, 1, RentalTypeUnitCodes.Hour, DateTime.Parse("2017-12-01T09:00:00"), DateTime.Parse("2017-12-01T19:00:00"), 10);
            var rentalDetail2 = Builder.CreateRentalDetail(ctx, bike2.BikeId, 1, RentalTypeUnitCodes.Day, DateTime.Parse("2017-12-01"), DateTime.Parse("2017-12-03"), 2);
            var rentalDetail3 = Builder.CreateRentalDetail(ctx, bike3.BikeId, 1, RentalTypeUnitCodes.Week, DateTime.Parse("2017-12-01"), DateTime.Parse("2017-12-08"), 1);
            var rentalDetail4 = Builder.CreateRentalDetail(ctx, bike4.BikeId, 1, RentalTypeUnitCodes.Week, DateTime.Parse("2017-12-01"), DateTime.Parse("2017-12-08"), 1);
            var rentalDetail5 = Builder.CreateRentalDetail(ctx, bike5.BikeId, 1, RentalTypeUnitCodes.Week, DateTime.Parse("2017-12-01"), DateTime.Parse("2017-12-08"), 1);
            var rentalDetail6 = Builder.CreateRentalDetail(ctx, bike6.BikeId, 1, RentalTypeUnitCodes.Week, DateTime.Parse("2017-12-01"), DateTime.Parse("2017-12-08"), 1);
            var rentalDetails = new List<RentalDetail>();
            rentalDetails.Add(rentalDetail1);
            rentalDetails.Add(rentalDetail2);
            rentalDetails.Add(rentalDetail3);
            rentalDetails.Add(rentalDetail4);
            rentalDetails.Add(rentalDetail5);
            rentalDetails.Add(rentalDetail6);
            var promotion = ctx.Promotions.Where(x => x.PromotionId == 1).FirstOrDefault();
            var promotionRules = ctx.PromotionRules.ToList();

            //Act
            Rental rental = controller.RentBikes(rentalDetails, "Several bikes different rental types", client, promotion, promotionRules);

            //Assert
            var subTotal = rentalDetail1.NumberOfUnits * rentalDetail1.RentalType.PriceUnit +
                rentalDetail2.NumberOfUnits * rentalDetail2.RentalType.PriceUnit +
                rentalDetail3.NumberOfUnits * rentalDetail3.RentalType.PriceUnit +
                rentalDetail4.NumberOfUnits * rentalDetail4.RentalType.PriceUnit +
                rentalDetail5.NumberOfUnits * rentalDetail5.RentalType.PriceUnit +
                rentalDetail6.NumberOfUnits * rentalDetail6.RentalType.PriceUnit;
            var total = subTotal - (subTotal * promotion.Discount.Amount);
            Assert.AreEqual(subTotal, rental.Total);
            Assert.AreNotEqual(total, rental.Total);
        }
    }
}
