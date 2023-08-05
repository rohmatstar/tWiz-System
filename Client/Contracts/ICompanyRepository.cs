using Client.DTOs;
using Client.DTOs.Companies;

namespace Client.Contracts
{
    public interface ICompanyRepository : IRepository<GetCompanyDto, Guid>
    {
        public Task<ResponseListDto<GetCompanyDto>> GetCompany();
    }
}
