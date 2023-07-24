using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class RegisterPaymentRepository : GeneralRepository<RegisterPayment>, IRegisterPaymentRepository
{
    public RegisterPaymentRepository(TwizDbContext context) : base(context)
    {
    }
}
