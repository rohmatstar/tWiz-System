using API.DTOs.RegisterPayments;
using API.Models;
using API.Utilities.Enums;

namespace API.Contracts;

public interface IRegisterPaymentRepository : IGeneralRepository<RegisterPayment>
{
    public bool UpdatePaymentImage(PaymentSubmissionDto paymentSubmissionDto);

    public bool ChangeStatusRegisterPayment(Guid registerPaymentGuid, StatusPayment statusPayment);
}
