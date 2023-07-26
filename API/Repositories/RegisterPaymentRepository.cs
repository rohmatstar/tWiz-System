using API.Contracts;
using API.Data;
using API.Models;
using API.Utilities.Enums;

namespace API.Repositories;

public class RegisterPaymentRepository : GeneralRepository<RegisterPayment>, IRegisterPaymentRepository
{
    public RegisterPaymentRepository(TwizDbContext context) : base(context)
    {
    }

    public bool UpdatePaymentImage(Guid guid, string paymentImageUrl = "")
    {
        try
        {
            var registerPaymentByGuid = _context.Set<RegisterPayment>().Find(guid);

            if (registerPaymentByGuid is null)
            {
                return false;
            }

            if (paymentImageUrl != "")
            {
                registerPaymentByGuid.PaymentImage = paymentImageUrl;
                _context.SaveChanges();
                return true;
            }

            return false;


        }
        catch { return false; }

    }

    public bool ChangeStatusRegisterPayment(Guid registerPaymentGuid, StatusPayment statusPayment)
    {
        try
        {
            var registerPaymentByGuid = _context.Set<RegisterPayment>().Find(registerPaymentGuid);

            if (registerPaymentByGuid is null)
            {
                return false;
            }

            registerPaymentByGuid.StatusPayment = statusPayment;
            _context.SaveChanges();

            return true;
        }
        catch { return false; }

    }
}
