using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterTrackerAPI.Entities;
using WaterTrackerAPI.Extensions;
using WaterTrackerAPI.Repositories.IRepositories;
using WaterTrackerApp.Models.Dtos;

namespace WaterTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterIntakeController : ControllerBase // A controller which handles the CRUD operations for the WaterIntake Entity
    {
        //Create unit of work interface for dependancy injection
        private readonly IUnitOfWork _unitOfWork;

        //Inject unit of work
        public WaterIntakeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Get request which returns all Water based on the record id
        [HttpGet("getById/{id:int}")]    
        public async Task<ActionResult<WaterIntakeDto>> GetWaterIntake(int id)
        {


            try
            {
                var record = await _unitOfWork.WaterIntake.Get(x=> x.Id==id,includeProperties: "User");
                var recordDtos = record.ConvertToWaterIntakeDto();
                return Ok(recordDtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }


        }
        //Get request which returns ass Water Intake records
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterIntakeDto>>> GetAllWaterIntake()
        {


            try
            {
                var records = await _unitOfWork.WaterIntake.GetAll(includeProperties:"User");
                var recordDtos = records.ConvertToWaterIntakesDto();
                return Ok(recordDtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

            
        }
        //Get request which returns all records for a specific user
        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<WaterIntakeDto>>> GetAllUsersWaterIntake(int id)
        {


            try
            {
                var records = await _unitOfWork.WaterIntake.GetAll(x => x.UserID == id ,includeProperties: "User");
                var recordDtos = records.ConvertToWaterIntakesDto();
                return Ok(recordDtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        //Post request which creates a water intake record for a specific record
        [HttpPost]
        public async Task<ActionResult<WaterIntakeDto>> CreateWaterIntakeRecord(WaterIntakeDto Dto)
        {
            try
            {
                if (Dto == null)
                {
                    return BadRequest();
                }
                WaterIntake record = Dto.ConvertDtoToWaterIntake();
                _unitOfWork.WaterIntake.Add(record);
                await _unitOfWork.Save();
                return CreatedAtAction(nameof(CreateWaterIntakeRecord),
                new { id = record.Id }, record);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new user record");
            }
        }

        //Put request which updates a water intake record for a specific user 
        [HttpPut("{id:int}")]
        public async Task<ActionResult<WaterIntakeDto>> UpdateRecord(WaterIntakeDto RecordDto, int id)
        {
            try
            {
                if (id != RecordDto.Id)
                {
                    return BadRequest("Record ID mismatch");
                }


                var RecordToUpdate = await _unitOfWork.WaterIntake.Get(x => x.Id == id);

                if (RecordToUpdate == null)
                {
                    return NotFound($"Record with Id = {id} not found");
                }


                WaterIntake record = RecordDto.ConvertDtoToWaterIntake();
                await _unitOfWork.WaterIntake.Update(record, id);
                await _unitOfWork.Save();
                return Ok(record);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
        
        //Delete request which deletes a water intake record for a specific user
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<WaterIntake>> DeleteRecord(int id)
        {
            try
            {

                WaterIntake user = await _unitOfWork.WaterIntake.Get(x => x.Id == id);
                await _unitOfWork.WaterIntake.Remove(user);
                await _unitOfWork.Save();
                return Ok(User);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Deleting data");
            }
        }

    }
}
