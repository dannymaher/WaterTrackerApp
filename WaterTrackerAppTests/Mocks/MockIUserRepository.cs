using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterTrackerAPI.Entities;
using WaterTrackerAPI.Repositories.IRepositories;

namespace WaterTrackerAppTests.Mocks
{
    internal class MockIUserRepository
    {
        public static Mock<IUserRepository> GetMock()
        {
            var mock = new Mock<IUserRepository>();
            
            var users = new List<User>() {
            new User()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith",
                Email = "johnsmith@gmail.com"
                
               
            }
            
        };
            // Set up
            mock.Setup(x => x.GetAll(x => x.Id == 1, null,null)).Returns(() => users);
            //mock.Setup(x => x.Get(x => x.Id == 1, null,false)).Returns((int id) => users.FirstOrDefault(x => x.Id == id));


            return mock;
        }

       
    }
}
