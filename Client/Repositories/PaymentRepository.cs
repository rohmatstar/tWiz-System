using Client.Contracts;
using Client.DTOs;
using Client.DTOs.Auths;
using Client.DTOs.RegisterPayments;
using Newtonsoft.Json;
using System.Text;

namespace Client.Repositories;

public class PaymentRepository : GeneralRepository<RegisterDto, string>, IPaymentRepository
{
    private readonly HttpClient httpClient;
    private readonly string request;

    public PaymentRepository(string request = "register-payments/summary") : base(request)
    {
        httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7249/api/")
        };
        this.request = request;
    }

    public async Task<ResponseDto<PaymentSummaryDto>> GetPaymentSummary(string email)
    {
        ResponseDto<PaymentSummaryDto> entity = null!;
        StringContent content = new StringContent(JsonConvert.SerializeObject(email), Encoding.UTF8, "application/json");
        var response = httpClient.GetAsync(request + "/" + email).Result;
        using (response)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entity = JsonConvert.DeserializeObject<ResponseDto<PaymentSummaryDto>>(apiResponse)!;
        }
        return entity;
    }

}
