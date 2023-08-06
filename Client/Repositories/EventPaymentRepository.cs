using Client.Contracts;
using Client.DTOs;
using Client.DTOs.EventPayments;
using Newtonsoft.Json;

namespace Client.Repositories;

public class EventPaymentRepository : GeneralRepository<GetEventPaymentDto, Guid>, IEventPaymentRepository
{
    public EventPaymentRepository(string request = "event-payments") : base(request)
    {
    }

    public async Task<ResponseListDto<EventPaymentSummaryDto>> GetSummary(Guid guid)
    {
        ResponseListDto<EventPaymentSummaryDto> entityVM = null;
        using (var response = await httpClient.GetAsync(request + $"/summary?guid={guid}"))
        {
            Console.WriteLine($"response : {response}");
            Console.WriteLine($"response isSuccess : {response.IsSuccessStatusCode}");

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();

                entityVM = JsonConvert.DeserializeObject<ResponseListDto<EventPaymentSummaryDto>>(apiResponse);

            }
            else
            {
                entityVM = new ResponseListDto<EventPaymentSummaryDto> { Code = (int)response.StatusCode, Message = response.ReasonPhrase, Data = null };
            }


        }
        return entityVM;
    }
}

