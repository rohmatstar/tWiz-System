using API.Models;
using Client.Contracts;
using Client.DTOs;
using System.Text;
using API.DTOs.Auths;
using Newtonsoft.Json;
using API.DTOs.Events;

namespace Client.Repositories
{
    public class EventRepository : GeneralRepository<EventsDto, string>, IEventRepository
    {
        private readonly HttpClient httpClient;
        private readonly string request;

        public EventRepository(string request = "events/") : base(request)
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7249/api/")
            };
            this.request = request;
        }

        /*public async Task<ResponseDto<string>> Login(LoginDto loginDto)
        {
            ResponseDto<string> entity = null!;
            StringContent content = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request + "login", content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseDto<string>>(apiResponse)!;
            }
            return entity;
        }

        public async Task<ResponseMessageDto> Register(RegisterDto entity)
        {
            ResponseMessageDto entityDto = null!;
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request + "register", content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityDto = JsonConvert.DeserializeObject<ResponseMessageDto>(apiResponse)!;
            }
            return entityDto;
        }*/
    }
}