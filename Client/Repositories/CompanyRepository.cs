using Client.Contracts;
using Client.DTOs;
using Client.DTOs.Companies;
using Newtonsoft.Json;

namespace Client.Repositories
{
    public class CompanyRepository : GeneralRepository<GetCompanyDto, Guid>, ICompanyRepository
    {
        public CompanyRepository(string request = "companies/") : base(request)
        {
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
