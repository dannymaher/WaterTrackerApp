using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Reflection.Metadata;
using WaterTrackerAPI.Controllers;
using WaterTrackerAPI.Data;
using WaterTrackerAPI.Entities;
using WaterTrackerAPI.Repositories;
using WaterTrackerAppTests.Mocks;
using Xunit;
using Xunit.Sdk;

namespace WaterTrackerAppTests
{
    public class UnitofWorkTests
    {


        [Fact]
        public void WhenGettingAllUser_ThenAllUsersReturn()
        {
            var unitofWorkMock = MockUnitOfWork.GetMock();
            
            var userController = new UserController(unitofWorkMock.Object)   ;

            var result =  userController.GetAllUsers();
            
            Assert.NotNull(result);
            
;           //Assert.Equal(, result.Result);
            
            
            Assert.IsAssignableFrom<IEnumerable<User>>(result.Result.Value);
            //Assert.IsAssignableFrom<IEnumerable<OwnerDto>>(result.Value);
            //Assert.NotEmpty(result );
        }



    }
}