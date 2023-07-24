using API.Contracts;
using API.Data;
using API.Models;
using API.DTOs.EventDocs;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class EventDocRepository : GeneralRepository<EventDoc>, IEventDocRepository
    {
        public EventDocRepository(TwizDbContext context) : base(context) {}

        public new EventDocsDto? GetByGuid(Guid guid)
        {
            return _context.Set<EventDocsDto>().Find(guid);
        }
    }
}
