using SensadeData.DatabaseLayer;
using SensadeData.Models;

namespace API.BusinessLogic
{
    public class ParkingSpaceLogic : IParkingSpaceLogic
    {
        private readonly IParkingSpace _parkingSpace;
        public ParkingSpaceLogic(IParkingSpace parkingSpace)
        {
            _parkingSpace = parkingSpace;

        }
        public int CountSpacesByStatus(int areaId, int status)
        {
            return _parkingSpace.CountSpacesByStatus(areaId, status);
        }

        public bool CreateParkingSpace(ParkingSpace ps)
        {
            return _parkingSpace.CreateParkingSpace(ps);
        }

        public bool DeleteParkingSpace(int id)
        {
            return _parkingSpace.DeleteParkingSpace(id);
        }

        public List<ParkingSpace?>? GetParkingSpaceByIdOrAll(int id = -1)
        {
            return _parkingSpace.GetParkingSpaceByIdOrAll(id);
        }

        public List<ParkingSpace?>? GetSpacesFromArea(int areaId)
        {
            return _parkingSpace.GetSpacesFromArea(areaId);
        }

        public bool UpdateParkingSpace(ParkingSpace ps)
        {
            return _parkingSpace.UpdateParkingSpace(ps);
        }

        public bool UpdateStatus(int id, ParkingStatus status)
        {
            return  _parkingSpace.UpdateStatus(id, status);
        }
    }
}

  