using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WaterTrackerApp.Models.Dtos;

namespace WaterTrackerAppTests
{
    public class WaterIntakeControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _client;
        public WaterIntakeControllerIntegrationTests(TestingWebAppFactory<Program> factory)
            => _client = factory.CreateClient();

        [Fact]
        public async Task GetWaterIntakeByIdReturns200AndContainsFK()
        {
            var response = await _client.GetAsync($"api/WaterIntake/getById/{1}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("5431", responseString);
            Assert.Contains("1", responseString);
            Assert.Contains("Danny Maher", responseString);
            

        }

        [Fact]
        public async Task GetInvalidWaterIntakeByIdReturns400()
        {

            var response = await _client.GetAsync($"api/WaterIntake/getById/{100000}");
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            
        }
        [Fact]
        public async Task GetAllWaterIntakesReturns200AndAllRecords()
        {
            var response = await _client.GetAsync("/api/WaterIntake");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("5431", responseString);
            Assert.Contains("67777", responseString);
            Assert.Contains("445556", responseString);
            


        }
        [Fact]
        public async Task ValidGetAllUsersWaterIntakeReturns200()
        {
            var response = await _client.GetAsync($"/api/WaterIntake/{1}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("5431", responseString);
            Assert.Contains("10456", responseString);
            Assert.Contains("2234", responseString);
            Assert.Contains("67777", responseString);
        }
        
        [Fact]
        public async Task AddValidWaterIntakeReturns200()
        {
            
            WaterIntakeDto water= new WaterIntakeDto { Id=0,IntakeDate=DateTime.Now,ConsumedWater=555,UserID=1,UserName="Danny Maher"};



            var response = await _client.PostAsJsonAsync("api/WaterIntake", water);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("555", responseString);
        }

        [Fact]
        public async Task AddInvalidWaterIntakeReturns400()
        {
            WaterIntakeDto water = new WaterIntakeDto { Id = 0, IntakeDate = DateTime.Now, ConsumedWater = -555, UserID = 1, UserName = "Danny Maher" };




            var response = await _client.PostAsJsonAsync("api/WaterIntake", water);



            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task UpdateValidWaterIntakeReturns200()
        {
            WaterIntakeDto water = new WaterIntakeDto { Id = 13, IntakeDate = DateTime.Now, ConsumedWater = 5557, UserID = 4, UserName = "Chloe Lee" };




            var response = await _client.PutAsJsonAsync($"api/WaterIntake/{13}", water);



            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task UpdatMismatchIdAndRecordIDReturns400()
        {
            

            WaterIntakeDto water = new WaterIntakeDto { Id = 13, IntakeDate = DateTime.Now, ConsumedWater = 5557, UserID = 4, UserName = "Chloe Lee" };


            var response = await _client.PutAsJsonAsync($"api/WaterIntake/{2}", water);



            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task UpdatInvalidWaterIntakeWithInvalidFieldReturns400()
        {
            WaterIntakeDto water = new WaterIntakeDto { Id = 13, IntakeDate = DateTime.Now, ConsumedWater = -5557, UserID = 4, UserName = "Chloe Lee" };


            var response = await _client.PutAsJsonAsync($"api/WaterIntake/{13}", water);



            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task DeleteWaterIntakeWithInvalidIdReturns500()
        {

            var response = await _client.DeleteAsync($"api/WaterIntake/{30000}"); ;
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task DeleteUserWithInvalidIdReturns200()
        {

            var response = await _client.DeleteAsync($"api/WaterIntake/{16}"); ;
            response.EnsureSuccessStatusCode();
        }
    }
}
