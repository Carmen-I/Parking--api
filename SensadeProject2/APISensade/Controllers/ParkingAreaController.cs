using API.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using SensadeData.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingAreasController : ControllerBase

    {
        private readonly IParkingAreaLogic _parkingAreaLogic;
        public ParkingAreasController(IParkingAreaLogic parkingAreaLogic) {
        _parkingAreaLogic = parkingAreaLogic;
        }
        
        [HttpGet]
        public ActionResult<List<ParkingArea>> GetAllParkingPlaces()
        {
            ActionResult result;
            try
            {
                List<ParkingArea> areas = _parkingAreaLogic.GetParkingAreaByIdOrAll();
                if (areas.Count > 0)
                {
                    result = Ok(areas);
                }
                else
                {
                    result = NotFound("No parking areas found.");
                }
            }
            catch (NpgsqlException)
            {
                result = StatusCode(500, "Something went wrong finding parking areas.");
            }
            return result;
        }


        

        
        [HttpGet("{id}")]
        public ActionResult<ParkingArea> GetParkingPlaceById(int id)
        {
            ActionResult result;
            try
            {
                ParkingArea area = _parkingAreaLogic.GetParkingAreaByIdOrAll(id).FirstOrDefault();
                if (area != null)
                {
                    result = Ok(area);
                }
                else
                {
                    result = NotFound($"No such area found for parking  {id}.");
                }

            }
            catch (NpgsqlException)
            {
                return StatusCode(500, "Something went wrong with finding the specified parking area.");
            }
            return result;
        }
      

     
        
        [HttpPut]
        public ActionResult<bool> Put( [FromBody] ParkingArea pa)
        {
            ActionResult result;
            try
            {
                bool updated = _parkingAreaLogic.UpdateParkingArea(pa);  
                if (updated)
                {
                    result = Ok(updated);
                }
                else
                {
                    result = BadRequest("Failed to update parking area.");
                }
            }
            catch (NpgsqlException)
            {
                return StatusCode(500, "Something went wrong with updating the parking area");
            }
            return result;
        }
   

        
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            ActionResult result;
            try
            {
                bool deleted = _parkingAreaLogic.DeleteParkingArea(id);
                if (deleted)
                {
                    result = Ok(deleted);
                }
                else
                {
                    result = BadRequest("Failed to delete parking area.");
                }
            }
            catch (NpgsqlException)
            {
                return StatusCode(500, "Something went wrong with deleting the parking area");
            }

            return result;



        }
    }
}
