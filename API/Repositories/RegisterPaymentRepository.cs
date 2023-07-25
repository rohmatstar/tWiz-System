using API.Contracts;
using API.Data;
using API.DTOs.RegisterPayments;
using API.Models;
using API.Utilities.Enums;

namespace API.Repositories;

public class RegisterPaymentRepository : GeneralRepository<RegisterPayment>, IRegisterPaymentRepository
{
    public RegisterPaymentRepository(TwizDbContext context) : base(context)
    {
    }

    public bool UpdatePaymentImage(PaymentSubmissionDto paymentSubmissionDto)
    {
        try
        {
            var registerPaymentByGuid = _context.Set<RegisterPayment>().Find(paymentSubmissionDto.Guid);

            if (registerPaymentByGuid is null)
            {
                return false;
            }

            if (paymentSubmissionDto.PaymentImageUrl != null)
            {
                registerPaymentByGuid.PaymentImage = paymentSubmissionDto.PaymentImageUrl;
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
