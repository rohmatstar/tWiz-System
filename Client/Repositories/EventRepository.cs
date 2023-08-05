﻿using Client.Contracts;
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

    public async Task<ResponseListDto<GetEventDto>> GetInternal(QueryParamGetEventDto queryParams)
    {
        ResponseListDto<GetEventDto> entityVM = null;
        using (var response = await httpClient.GetAsync(request + $"/internal?visibility={queryParams.visibility}&publication_status={queryParams.publication_status}&place_type={queryParams.place_type}&sort_by={queryParams.sort_by}"))
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
