using Microsoft.AspNetCore.Mvc;
using WaterTrackerAPI.Entities;
using WaterTrackerAPI.Extensions;
using WaterTrackerAPI.Repositories;
using WaterTrackerAPI.Repositories.IRepositories;
using WaterTrackerApp.Models.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase // A controller which handles the CRUD operations for the User Entity
    {
        //Create unit of work interface for dependancy injection
        private readonly IUnitOfWork _unitOfWork;

        //Inject unit of work
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Get request which returns all users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {


            try
            {
                var Users = await _unitOfWork.User.GetAll();
                var UserDtos = Users.ConvertToUsersDto();
                return Ok(UserDtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        //Get request with an integer parameter which returns a user
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            try
            {
                var User = await _unitOfWork.User.Get(x => x.Id == id);
                var UserDto = User.ConvertToUserDto();
                
                if (UserDto == null)
                {
                    return NotFound();
                }
                return Ok(UserDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        
        //Post request which creates a user entity in the db
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(UserDto UserDto)
        {
            try
            {
                if(UserDto == null)
                {
                    return BadRequest();
                }
                User NewUser = UserDto.ConvertDtoToUser();
                _unitOfWork.User.Add(NewUser);
                _unitOfWork.Save();
                return CreatedAtAction(nameof(GetUserById),
                new { id = NewUser.Id }, NewUser);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new user record");
            }
        }

        //Post request which creates a user entity in the db
        [HttpPut("{id:int}")]
        public async Task<ActionResult<User>> UpdateUser(UserDto UserDto, int id)
        {
            try
            {
                if (id != UserDto.Id)
                {
                    return BadRequest("User ID mismatch");
                }


                var UserToUpdate = await _unitOfWork.User.Get(x => x.Id == id);

                if (UserToUpdate == null)
                {
                    return NotFound($"User with Id = {id} not found");
                }


                User user = UserDto.ConvertDtoToUser();
                await _unitOfWork.User.Update(user,id);
                await _unitOfWork.Save();
                return Ok(User);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
        
        //Delete request which deletes a user and their water intake records from the db
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            try
            {
                
                User user = await _unitOfWork.User.Get(x => x.Id == id);
                await _unitOfWork.User.Remove(user);
                await _unitOfWork.Save();
                return Ok(User);
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Deleting data");
            }
        }

    }
}
