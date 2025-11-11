using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensadeData.Models;

namespace SensadeData.DatabaseLayer
{
    public interface IParkingSpace
    {
        bool CreateParkingSpace(ParkingSpace ps);
        List<ParkingSpace?>? GetParkingSpaceByIdOrAll(int id = -1);
        List<ParkingSpace?>? GetSpacesFromArea(int areaId);
        bool UpdateParkingSpace(ParkingSpace ps);
        bool DeleteParkingSpace(int id);
        bool UpdateStatus(int id,ParkingStatus status);
        int CountSpacesByStatus(int areaId, int status);
    }

}
