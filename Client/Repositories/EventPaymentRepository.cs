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

    public async Task<ResponseDto<EventPaymentSummaryDto>> GetSummary(Guid guid)
    {
        ResponseDto<EventPaymentSummaryDto> entityVM = null;
        using (var response = await httpClient.GetAsync(request + $"/summary?guid={guid}"))
        {
            Console.WriteLine($"response : {response}");
            Console.WriteLine($"response isSuccess : {response.IsSuccessStatusCode}");

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();

                entityVM = JsonConvert.DeserializeObject<ResponseDto<EventPaymentSummaryDto>>(apiResponse);

            }
            else
            {
                entityVM = new ResponseDto<EventPaymentSummaryDto> { Code = (int)response.StatusCode, Message = response.ReasonPhrase, Data = null };
            }


        }
        return entityVM;
    }

    public async Task<ResponseDto<GetParticipantsPaidEventDto>> GetParticipantsPaidEvent(Guid eventGuid)
    {
        ResponseDto<GetParticipantsPaidEventDto> entityVM = null;
        using (var response = await httpClient.GetAsync(request + $"/participants-paid-event?eventGuid={eventGuid}"))
        {
            Console.WriteLine($"response : {response}");
            Console.WriteLine($"response isSuccess : {response.IsSuccessStatusCode}");

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();

                entityVM = JsonConvert.DeserializeObject<ResponseDto<GetParticipantsPaidEventDto>>(apiResponse);

            }
            else
            {
                entityVM = new ResponseDto<GetParticipantsPaidEventDto> { Code = (int)response.StatusCode, Message = response.ReasonPhrase, Data = null };
            }


        }
        return entityVM;
    }


}

