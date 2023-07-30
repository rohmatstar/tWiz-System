using API.Models;

namespace API.Contracts;

public interface IEventRepository : IGeneralRepository<Event>
{
    public IEnumerable<Event> GetEventsByCreatedBy(Guid companyGuid);
}
