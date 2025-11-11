using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensadeData.Models
{
    public class ParkingArea
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public  string ZipCode { get; set; }
        public double Latitude {  get; set; }
        public double Longitude { get; set; }
        public List<ParkingSpace> ParkingSpaces { get; set; } = new();

    }
}
