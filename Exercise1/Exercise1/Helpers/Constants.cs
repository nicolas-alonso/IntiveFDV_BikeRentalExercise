using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Helpers
{
    public class Constants
    {
        public static class RentalTypeUnits
        {
            public const string Hour = "H";
            public const string Day = "D";
            public const string Week = "W";
        }

        public static class RentalTypeUnitCodes
        {
            public const int Hour = 1;
            public const int Day = 2;
            public const int Week = 3;
        }

        public static class DiscountTypes
        {
            public const string Percentage = "PER";
            public const string Currency = "CUR";
        }

        public static class ConditionTypes
        {
            public const string FamilyRental = "FAM";
        }
    }
}
