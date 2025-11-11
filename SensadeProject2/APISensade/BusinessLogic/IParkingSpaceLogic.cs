using SensadeData.Models;


namespace API.BusinessLogic
{
    public interface IParkingSpaceLogic
    {
        bool CreateParkingSpace(ParkingSpace ps);
        List<ParkingSpace?>? GetParkingSpaceByIdOrAll(int id = -1);
        List<ParkingSpace?>? GetSpacesFromArea(int areaId);
        bool UpdateParkingSpace(ParkingSpace ps);
        bool DeleteParkingSpace(int id);
        bool UpdateStatus(int id, ParkingStatus status);
        int CountSpacesByStatus(int areaId, int status);
    }
}
