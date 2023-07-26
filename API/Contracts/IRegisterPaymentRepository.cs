using API.Models;
using API.Utilities.Enums;

namespace API.Contracts;

public interface IRegisterPaymentRepository : IGeneralRepository<RegisterPayment>
{
    public bool UpdatePaymentImage(Guid guid, string imageUrl);

    public bool ChangeStatusRegisterPayment(Guid registerPaymentGuid, StatusPayment statusPayment);
}
