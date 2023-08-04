using Client.Contracts;
using Client.DTOs;
using Client.DTOs.Events;
using Newtonsoft.Json;

namespace Client.Repositories;

public class EventRepository : GeneralRepository<EventsDto, Guid>, IEventRepository
{

    public EventRepository(string request = "events") : base(request)
    {
    }

    public async Task<ResponseListDto<GetEventDto>> Getall()
    {
        ResponseListDto<GetEventDto> entityVM = null;
        using (var response = await httpClient.GetAsync(request))
        {
            Console.WriteLine($"response : {response}");
            Console.WriteLine($"response isSuccess : {response.IsSuccessStatusCode}");

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();

                entityVM = JsonConvert.DeserializeObject<ResponseListDto<GetEventDto>>(apiResponse);

            }
            else
            {
                entityVM = new ResponseListDto<GetEventDto> { Code = (int)response.StatusCode, Message = response.ReasonPhrase };
            }


        }
        return entityVM;
    }
}

