using API.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using SensadeData.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingSpacesController : ControllerBase
    {

        private readonly IParkingSpaceLogic _parkingSpaceLogic;
        
        public ParkingSpacesController(IParkingSpaceLogic parkingSpaceLogic)
        {
           _parkingSpaceLogic = parkingSpaceLogic;
        }
        
        [HttpGet]
        public ActionResult<List<ParkingSpace>> GetAllOrById(int id = -1)
        {
            ActionResult result;
            try
            {
                var spaces = _parkingSpaceLogic.GetParkingSpaceByIdOrAll(id);
                if (spaces != null && spaces.Count > 0)
                {
                    result = Ok(spaces);
                }
                else
                {
                    result = NotFound("No parking spaces found.");
                }
            }
            catch (NpgsqlException)
            {
                result = StatusCode(500, "Something went wrong while retrieving parking spaces.");
            }

            return result;
        }

        [HttpGet("area/{id}")]
        public ActionResult<List<ParkingSpace>> GetByArea(int id)
        {
            ActionResult result;
            try
            {
                var spaces = _parkingSpaceLogic.GetSpacesFromArea(id);
                if (spaces != null && spaces.Count > 0)
                {
                    result = Ok(spaces);
                }
                else
                {
                    result = NotFound($"No spaces found for parking area {id}.");
                }
            }
            catch (NpgsqlException)
            {
                result = StatusCode(500, "Something went wrong while retrieving spaces by area.");
            }

            return result;
        }

        [HttpPost]
        public ActionResult<bool> Create([FromBody] ParkingSpace ps)
        {
            ActionResult result;
            try
            {
                bool created = _parkingSpaceLogic.CreateParkingSpace(ps);
                if (created)
                {
                    result = Ok(created);
                }
                else
                {
                    result = BadRequest("Failed to create parking space.");
                }
            }
            catch (NpgsqlException)
            {
                result = StatusCode(500, "Something went wrong while creating parking space.");
            }

            return result;
        }

        [HttpPut]
        public ActionResult<bool> Update([FromBody] ParkingSpace ps)
        {
            ActionResult result;
            try
            {
                bool updated = _parkingSpaceLogic.UpdateParkingSpace(ps);
                if (updated)
                {
                    result = Ok(updated);
                }
                else
                {
                    result = BadRequest("Failed to update parking space.");
                }
            }
            catch (NpgsqlException)
            {
                result = StatusCode(500, "Something went wrong while updating parking space.");
            }

            return result;
        }


        [HttpPatch("{id}/status/{status}")]
        public ActionResult<bool> UpdateStatus(int id, ParkingStatus status)
        {
            ActionResult result;
            try
            {
                bool updated = _parkingSpaceLogic.UpdateStatus(id, status);
                if (updated)
                {
                    result = Ok(updated);
                }
                else
                {
                    result = BadRequest("Failed to update parking space status.");
                }
            }
            catch (NpgsqlException)
            {
                result = StatusCode(500, "Something went wrong while updating parking space status.");
            }

            return result;
        }

        [HttpGet("area/{id}/total/{status}")]
        public ActionResult<int> GetCountByStatus(int id, int status)
        {
            ActionResult result;
            try
            {
                int count = _parkingSpaceLogic.CountSpacesByStatus(id, status);
                result = Ok(count);
            }
            catch (NpgsqlException)
            {
                result = StatusCode(500, "Something went wrong while counting spaces.");
            }
            return result;
        }


        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            ActionResult result;
            try
            {
                bool deleted = _parkingSpaceLogic.DeleteParkingSpace(id);
                if (deleted)
                {
                    result = Ok(deleted);
                }
                else
                {
                    result = BadRequest("Failed to delete parking space.");
                }
            }
            catch (NpgsqlException)
            {
                result = StatusCode(500, "Something went wrong while deleting parking space.");
            }

            return result;
        }
    }
}  

