using Client.Models;

namespace Client.Contracts
{
    public interface ICompanyRepository : IRepository<Company , Guid>
    {
    }
}
