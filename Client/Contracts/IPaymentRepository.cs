using Client.DTOs;
using Client.DTOs.Auths;
using Client.DTOs.RegisterPayments;

namespace Client.Contracts
{
    public interface IPaymentRepository : IRepository<RegisterDto, string>
    {
        public Task<ResponseDto<PaymentSummaryDto>> GetPaymentSummary(string email);
    }
}