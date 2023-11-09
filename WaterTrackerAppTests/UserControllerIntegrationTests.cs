using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WaterTrackerApp.Models.Dtos;
using static System.Net.Mime.MediaTypeNames;

namespace WaterTrackerAppTests
{
    public class UserControllerIntegrationTests: IClassFixture<TestingWebAppFactory<Program>>
    {
        
        private readonly HttpClient _client;
        public UserControllerIntegrationTests(TestingWebAppFactory<Program> factory)
            => _client = factory.CreateClient();

        [Fact]
        public async Task GetUsersReturns200AndUsers()
        {
            var response = await _client.GetAsync("/api/User");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Chloe", responseString);
            Assert.Contains("Mike", responseString);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
           
        }
        [Fact]
        public async Task GetValidUserByIdReturns400()
        {

            var response = await _client.GetAsync($"api/User/{1}");
            var responseString = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            Assert.Contains("Danny", responseString);
        }
        [Fact]
        public async Task GetInvalidUserByIdReturns404()
        {

            var response = await _client.GetAsync($"api/User/{300000}");
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task AddValidUserReturns200()
        {
            UserDto user = new UserDto {Id=0, Email = "newEmail@gmail.com", FirstName = "newFirst", LastName = "newLast" };




            var response = await _client.PostAsJsonAsync("api/User", user);

            response.EnsureSuccessStatusCode();
            
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("newFirst", responseString);
        }

        [Fact]
        public async Task AddInvalidUserReturns400()
        {
            UserDto user = new UserDto { Id = 0, Email = "newEmail", FirstName = "newFirst", LastName = "newLast" };




            var response = await _client.PostAsJsonAsync("api/User", user);

            

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task UpdateValidUserReturns200()
        {
            UserDto user = new UserDto { Id = 3, Email = "newEmail@gmail.com", FirstName = "newFirst", LastName = "newLast" };




            var response = await _client.PutAsJsonAsync($"api/User/{3}", user);



            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task UpdatMismatchIdAndUserReturns400()
        {
            UserDto user = new UserDto { Id = 3, Email = "newEmail@gmail.com", FirstName = "newFirst", LastName = "newLast" };




            var response = await _client.PutAsJsonAsync($"api/User/{2}", user);



            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task UpdatValidUserWithInvalidFieldReturns400()
        {
            UserDto user = new UserDto { Id = 3, Email = "newEmail@gmail.com", FirstName = "n", LastName = "newLast" };




            var response = await _client.PutAsJsonAsync($"api/User/{3}", user);



            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task DeleteUserWithInvalidIdReturns500()
        {

            var response = await _client.DeleteAsync($"api/User/{30000}"); ;
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task DeleteUserWithValidIdReturns200()
        {

            var response = await _client.DeleteAsync($"api/User/{3}"); ;
            response.EnsureSuccessStatusCode();
        }
    }
}
