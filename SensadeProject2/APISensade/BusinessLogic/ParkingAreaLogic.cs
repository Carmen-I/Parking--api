using SensadeData.DatabaseLayer;
using SensadeData.Models;

namespace API.BusinessLogic
{
    public class ParkingAreaLogic : IParkingAreaLogic
    {
        private readonly IParkingArea _parkingArea;
        public ParkingAreaLogic(IParkingArea parkingArea) {

             _parkingArea = parkingArea;
        }   
        public bool CreateParkingArea(ParkingArea pa)
        {
            return _parkingArea.CreateParkingArea(pa);
        }

        public bool DeleteParkingArea(int id)
        {
          return _parkingArea.DeleteParkingArea(id);
        }

        public List<ParkingArea?>? GetParkingAreaByIdOrAll(int id = -1)
        {
            return _parkingArea.GetParkingAreaByIdOrAll(id);
        }

        public bool UpdateParkingArea(ParkingArea pa)
        {
            return _parkingArea.UpdateParkingArea(pa);
        }
    }
}
