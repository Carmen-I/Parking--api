using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensadeData.Models
{
    public class ParkingSpace
    {
        public int Id {  get; set; }
        public ParkingStatus Status { get; set; }
        public int SpaceNumber {  get; set; }
    }

}
