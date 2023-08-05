using Client.Contracts;
using Client.DTOs;
using Client.DTOs.Companies;
using Newtonsoft.Json;

namespace Client.Repositories
{
    public class CompanyRepository : GeneralRepository<GetCompanyDto, Guid>, ICompanyRepository
    {
        private readonly HttpClient httpClient;
        private readonly string request;

        public CompanyRepository(string request = "companies/") : base(request)
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7249/api/")
            };
            this.request = request;
        }

        public async Task<ResponseListDto<GetCompanyDto>> GetCompany()
        {
            ResponseListDto<GetCompanyDto> entity = null!;
            var response = httpClient.GetAsync(request).Result;
            using (response)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseListDto<GetCompanyDto>>(apiResponse)!;
            }
            return entity;
        }
    }
}
