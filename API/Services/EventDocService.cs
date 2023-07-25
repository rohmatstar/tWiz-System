using API.Contracts;
using API.DTOs.EventDocs;
using API.Models;

namespace API.Services
{
    public class EventDocService
    {
        private readonly IEventDocRepository _eventDocRepository;

        public EventDocService(IEventDocRepository eventDocRepository)
        {
            _eventDocRepository = eventDocRepository;
        }

        public IEnumerable<EventDocsDto>? GetEventDocs()
        {
            var eventsModel = _eventDocRepository.GetAll();

            if (eventsModel is null)
            {
                return null;
            }

            var events = eventsModel.Select(e => new EventDocsDto
            {
                Guid = e.Guid,
                EventGuid = e.EventGuid,
                Documentation = e.Documentation
            }).ToList();

            return events;
        }

        public EventDocsDto? GetEventDoc(Guid guid)
        {
            var singleEvent = _eventDocRepository.GetByGuid(guid);
            if (singleEvent == null)
            {
                return null;
            }

            var e = singleEvent;

            var events = new EventDocsDto
            {
                Guid = e!.Guid,
                EventGuid = e!.EventGuid,
                Documentation = e.Documentation
            };

            return events;
        }

        public EventDocsDto? CreateEventDoc(CreateEventDocDto createEventDto)
        {
            var eventModel = new EventDoc
            {
                Guid = new Guid(),
                EventGuid = createEventDto.EventGuid!,
                Documentation = createEventDto.Documentation!
            };

            var created = _eventDocRepository.Create(eventModel);
            if (created is null)
            {
                return null;
            }


            var createdEvent = new EventDocsDto
            {
                Guid = eventModel.Guid,
                EventGuid = eventModel.EventGuid!,
                Documentation = eventModel.Documentation
            };

            return createdEvent;
        }

        public EventDocsDto? UpdateEventDoc(EventDocsDto eventDocsDto)
        {
            var singleEvent = _eventDocRepository.GetByGuid(eventDocsDto.Guid);
            if (singleEvent == null)
            {
                return null;
            }

            var eventModel = new EventDoc
            {
                Guid = eventDocsDto!.Guid,
                EventGuid = eventDocsDto.EventGuid!,
                Documentation = eventDocsDto.Documentation!,
            };

            var isUpdate = _eventDocRepository.Update(eventModel);
            if (!isUpdate)
            {
                return null;
            }

            var updatedEvent = new EventDocsDto
            {
                Guid = eventModel!.Guid,
                Documentation = eventModel.Documentation!
            };

            return updatedEvent;
        }

        public EventDocsDto? DeleteEventDoc(Guid guid)
        {
            var singleEvent = _eventDocRepository.GetByGuid(guid);
            if (singleEvent == null)
            {
                return null;
            }

            var isDelete = _eventDocRepository.Delete(singleEvent!);
            if (!isDelete)
            {
                return null;
            }

            var deletedEvent = new EventDocsDto
            {
                Guid = singleEvent.Guid,
                EventGuid = singleEvent.EventGuid,
                Documentation = singleEvent.Documentation!
            };

            return deletedEvent;
        }
    }
}
