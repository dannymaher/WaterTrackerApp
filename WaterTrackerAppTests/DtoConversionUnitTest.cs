using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterTrackerAPI.Entities;
using WaterTrackerAPI.Extensions;
using WaterTrackerApp.Models.Dtos;

namespace WaterTrackerAppTests
{
    public class DtoConversionUnitTest
    {
        [Fact]
        public void UserToUserDtoReturnsValid()
        {
            User user = new User { Id = 1, FirstName="Danny",LastName = "Maher",Email="dannymaher@gmail.com"};
            var result = user.ConvertToUserDto();
            Assert.Equal(1,result.Id);
            Assert.Equal(user.FirstName , result.FirstName );
            Assert.Equal( user.LastName, result.LastName);
            Assert.Equal(user.Email, result.Email);
        }

        [Fact]
        public void UsersToUserDtoListReturnsValid()
        {
            User user = new User { Id = 1, FirstName = "Danny", LastName = "Maher", Email = "dannymaher@gmail.com" };
            User user2 = new User { Id = 2, FirstName = "Frankie", LastName = "Maher", Email = "frankiemaher@gmail.com" };
            List<User> users = new List<User>{user,user2};
            var result = users.ConvertToUsersDto();

            Assert.Equal(2,users.Count);
            Assert.Equal(1, result.ElementAt(0).Id);
            Assert.Equal(user.FirstName, result.ElementAt(0).FirstName);
            Assert.Equal(user.LastName, result.ElementAt(0).LastName);
            Assert.Equal(user.Email, result.ElementAt(0).Email);
            Assert.Equal(2, result.ElementAt(1).Id);
            Assert.Equal(user2.FirstName, result.ElementAt(1).FirstName);
            Assert.Equal(user2.LastName, result.ElementAt(1).LastName);
            Assert.Equal(user2.Email, result.ElementAt(1).Email);
        }
        [Fact]
        public void UserDtoToUserReturnsValid()
        {
            UserDto userDto = new UserDto { Id = 1, FirstName = "Danny", LastName = "Maher", Email = "dannymaher@gmail.com" };
            var result = userDto.ConvertDtoToUser();
            Assert.Equal(1, result.Id);
            Assert.Equal(userDto.FirstName, result.FirstName);
            Assert.Equal(userDto.LastName, result.LastName);
            Assert.Equal(userDto.Email, result.Email);
        }

        [Fact]
        public void WaterIntakeToDtoReturnsValid()
        {
            User user = new User { Id = 1, FirstName = "Danny", LastName = "Maher", Email = "dannymaher@gmail.com" };
            WaterIntake waterIntake = new WaterIntake {Id = 1, ConsumedWater = 11, IntakeDate = new DateTime(2023, 5, 1, 8, 30, 52),UserID =1,User=user };
            
            var result = waterIntake.ConvertToWaterIntakeDto();
            Assert.Equal(1, result.Id);
            Assert.Equal(waterIntake.IntakeDate,result.IntakeDate);
            Assert.Equal(waterIntake.ConsumedWater,result.ConsumedWater);
            Assert.Equal(waterIntake.UserID,result.UserID);
            Assert.Equal("Danny Maher", result.UserName);
        }

        [Fact]
        public void WaterIntakeToDtoListReturnsValid()
        {
            User user = new User { Id = 1, FirstName = "Danny", LastName = "Maher", Email = "dannymaher@gmail.com" };
            User user2 = new User { Id = 2, FirstName = "Frankie", LastName = "Maher", Email = "frankiemaher@gmail.com" };
            WaterIntake waterIntake = new WaterIntake { Id = 1, ConsumedWater = 11, IntakeDate = new DateTime(2023, 5, 1, 8, 30, 52), UserID = 1, User = user };
            WaterIntake waterIntake2 = new WaterIntake { Id = 2, ConsumedWater = 99, IntakeDate = new DateTime(2023, 8, 8, 8, 30, 52), UserID = 2, User = user2 };
            List<WaterIntake> records = new List<WaterIntake> { waterIntake, waterIntake2 };
            var result = records.ConvertToWaterIntakesDto();

            Assert.Equal(2, result.Count());
            Assert.Equal(1, result.ElementAt(0).Id);
            Assert.Equal(waterIntake.IntakeDate, result.ElementAt(0).IntakeDate);
            Assert.Equal(waterIntake.ConsumedWater, result.ElementAt(0).ConsumedWater);
            Assert.Equal(waterIntake.UserID, result.ElementAt(0).UserID);
            Assert.Equal("Danny Maher", result.ElementAt(0).UserName);
            Assert.Equal(2, result.ElementAt(1).Id);
            Assert.Equal(waterIntake2.IntakeDate, result.ElementAt(1).IntakeDate);
            Assert.Equal(waterIntake2.ConsumedWater, result.ElementAt(1).ConsumedWater);
            Assert.Equal(waterIntake2.UserID, result.ElementAt(1).UserID);
            Assert.Equal("Frankie Maher", result.ElementAt(1).UserName);

        }
        [Fact]
        public void DtoToWaterIntakeReturnsValid()
        {
            User user = new User { Id = 1, FirstName = "Danny", LastName = "Maher", Email = "dannymaher@gmail.com" };
            WaterIntakeDto dto = new WaterIntakeDto { Id=1,ConsumedWater=88,IntakeDate = new DateTime(2023, 5, 1, 8, 30, 52) ,UserID = 1, UserName="Danny Maher"};
            var result = dto.ConvertDtoToWaterIntake();
            Assert.Equal(1, result.Id);
            Assert.Equal(dto.IntakeDate, result.IntakeDate);
            Assert.Equal(dto.UserName, user.FirstName + " " + user.LastName);
            Assert.Equal(dto.ConsumedWater, result.ConsumedWater);
        }
    }
}
