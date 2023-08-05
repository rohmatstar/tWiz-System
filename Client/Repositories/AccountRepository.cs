using Client.Contracts;
using Client.DTOs;
using Client.DTOs.Accounts;
using Newtonsoft.Json;

namespace Client.Repositories
{
    public class AccountRepository : GeneralRepository<GetAccountDto, Guid>, IAccountRepository
    {
        private readonly HttpClient httpClient;
        private readonly string request;

        public AccountRepository(string request = "accounts/") : base(request)
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7249/api/")
            };
            this.request = request;
        }

        public async Task<ResponseListDto<GetAccountDto>> GetAccount()
        {
            ResponseListDto<GetAccountDto> entity = null!;
            var response = httpClient.GetAsync(request).Result;
            using (response)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseListDto<GetAccountDto>>(apiResponse)!;
            }
            return entity;
        }
    }
}
