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
    internal class MockIWaterIntakeRepository
    {
        public static Mock<IWaterIntakeRepository> GetMock()
        {
            var mock = new Mock<IWaterIntakeRepository>();
            var WaterIntakes = new List<WaterIntake>() {
            new WaterIntake()
            {
                Id = 1,
               ConsumedWater = 1000,
               IntakeDate = DateTime.Now,
               UserID = 1,
               User = new User()
               {
                   Id = 1,
                    FirstName = "John",
                    LastName = "Smith",
                    Email = "johnsmith@gmail.com"
               }


            }
        };
            // Set up
            mock.Setup(x => x.GetAll(x => x.Id == 1, null, null)).Returns(() => WaterIntakes);
            //mock.Setup(x => x.Get(x => x.Id == 1, null, false)).Returns((int id) => WaterIntakes.FirstOrDefault(x => x.Id == id));


            return mock;
        }
    }
}
