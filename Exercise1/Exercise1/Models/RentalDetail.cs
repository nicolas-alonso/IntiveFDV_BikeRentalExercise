using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Models
{
    public class RentalDetail
    {
        public int BikeId { get; set; }
        public int RentalId { get; set; }
        public int RentalTypeId { get; set; }
        public virtual RentalType RentalType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfUnits { get; set; }
    }
}
