using API.DTOs.Auths;
using API.DTOs.Events;
using API.Models;
using Client.DTOs;

namespace Client.Contracts
{
    public interface IEventRepository : IRepository<EventsDto, string>
    {
        
    }
}