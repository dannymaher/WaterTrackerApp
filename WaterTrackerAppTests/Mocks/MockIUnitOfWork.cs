using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterTrackerAPI.Repositories.IRepositories;

namespace WaterTrackerAppTests.Mocks
{
    internal class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetMock()
        {
            var mock = new Mock<IUnitOfWork>();
            var UserRepoMock = MockIUserRepository.GetMock();
            var WaterRepoMock = MockIWaterIntakeRepository.GetMock();
            // Setup the mock

            mock.Setup(m => m.User).Returns(() => UserRepoMock.Object);
            mock.Setup(m => m.WaterIntake).Returns(() => WaterRepoMock.Object);
            mock.Setup(m => m.Save()).Callback(() => { return; });
            return mock;
        }
    }
}
