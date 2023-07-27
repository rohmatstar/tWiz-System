using Client.Contracts;
using Client.DTOs;
using System.Text;
using Newtonsoft.Json;
using Client.Models;
using Client.DTOs.Auths;

namespace Client.Repositories
{
    public class AuthRepository : GeneralRepository<Account, string>, IAuthRepository
    {
        private readonly HttpClient httpClient;
        private readonly string request;

        public AuthRepository(string request = "auths/") : base(request)
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7249/api/")
            };
            this.request = request;
        }

        public async Task<ResponseDto<string>> Login(LoginDto loginDto)
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
    }
}