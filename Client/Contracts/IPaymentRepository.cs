using API.DTOs.Auths;
using API.DTOs.RegisterPayments;
using Client.DTOs;
using Client.DTOs.Auths;

namespace Client.Contracts
{
    public interface IPaymentRepository : IRepository<RegisterDto, string>
    {
        public Task<ResponseDto<PaymentSummaryDto>> GetPaymentSummary(string email);
    }
}