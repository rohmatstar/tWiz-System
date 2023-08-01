using Client.DTOs.Companies;

namespace Client.Contracts
{
    public interface ICompanyRepository : IRepository<GetCompanyDto, Guid>
    {
    }
}
