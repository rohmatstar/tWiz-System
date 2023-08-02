using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class SysAdminRepository : GeneralRepository<SysAdmin>, ISysAdminRepository
{
    public SysAdminRepository(TwizDbContext context) : base(context)
    {
    }
}

