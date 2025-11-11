using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensadeData.Models;

namespace SensadeData.DatabaseLayer
{
    public interface IParkingArea
    {
        public bool CreateParkingArea(ParkingArea pa);
        public List<ParkingArea> GetParkingAreaByIdOrAll(int id=-1);
        public bool UpdateParkingArea(ParkingArea pa);
        public bool DeleteParkingArea(int id);
        
    }
}
