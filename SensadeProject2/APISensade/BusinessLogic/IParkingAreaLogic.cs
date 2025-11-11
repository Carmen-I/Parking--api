using SensadeData.Models;

namespace API.BusinessLogic
{
    public interface IParkingAreaLogic
    {
        bool CreateParkingArea(ParkingArea pa);
        List<ParkingArea?>? GetParkingAreaByIdOrAll(int id = -1);
        bool UpdateParkingArea(ParkingArea pa);
        bool DeleteParkingArea(int id);
    }
}
