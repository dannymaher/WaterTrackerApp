using WaterTrackerAPI.Entities;
using WaterTrackerApp.Models.Dtos;

namespace WaterTrackerAPI.Extensions
{
    // A class responsible for converting between db entities and their respective dto
    public static class DtoConversions
    {
        
        //converts a list of users to a list of user dtos
        public static IEnumerable<UserDto> ConvertToUsersDto(this IEnumerable<User> users)
        {
            List<UserDto> result = users.Select(x => new UserDto
            {
                Id = x.Id,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName

            }).ToList();
            return result;
        }
        //converts a user to a user dto
        public static UserDto ConvertToUserDto(this User user)
        {
            UserDto result = new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName

            };
            return result;
        }
        //converts a user dto  to a user
        public static User ConvertDtoToUser(this UserDto userDto)
        {
            User result = new User
            {
                Id = userDto.Id,
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName

            };
            return result;
        }
       //converts a list of Water intake record to a list of water intake dto
        public static IEnumerable<WaterIntakeDto> ConvertToWaterIntakesDto(this IEnumerable<WaterIntake> records)
        {
            List<WaterIntakeDto> result = records.Select(x => new WaterIntakeDto
            {
                Id = x.Id,
                ConsumedWater = x.ConsumedWater,
                IntakeDate = x.IntakeDate,
                UserID = x.User.Id,
                UserName = x.User.FirstName + " " + x.User.LastName

            }).ToList();
            return result;
        }
        //converts a Water intake record to a water intake dto
        public static WaterIntakeDto ConvertToWaterIntakeDto(this WaterIntake records)
        {
            WaterIntakeDto result = new WaterIntakeDto
            {
                Id = records.Id,
                ConsumedWater = records.ConsumedWater,
                IntakeDate = records.IntakeDate,
                UserID = records.User.Id,
                UserName = records.User.FirstName + " " + records.User.LastName

            };
            return result;
        }
        // converts a water intake dto to a water intake
        public static WaterIntake ConvertDtoToWaterIntake(this WaterIntakeDto record)
        {
            WaterIntake result = new WaterIntake
            {
                Id= record.Id,
                ConsumedWater = record.ConsumedWater,
                IntakeDate = record.IntakeDate,
                UserID =record.UserID
            };
            return result;
        }
    }
}
