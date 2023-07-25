using API.Contracts;
using API.DTOs.EmployeeParticipants;
using API.Models;

namespace API.Services
{
    public class EmployeeParticipantService
    {
        private readonly IEmployeeParticipantRepository _repository;

        public EmployeeParticipantService(IEmployeeParticipantRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<EmployeeParticipantsDto>? GetAll()
        {
            var model = _repository.GetAll();

            if (model is null)
            {
                return null;
            }

            var data = model.Select(e => new EmployeeParticipantsDto
            {
                Guid = e.Guid,
                EventGuid = e.EventGuid,
                EmployeeGuid = e.EmployeeGuid,
                IsJoin = e.IsJoin,
                IsPresent = e.IsPresent
            }).ToList();

            return data;
        }

        public EmployeeParticipantsDto? GetSingle(Guid guid)
        {
            var model = _repository.GetByGuid(guid);

            if (model is null)
            {
                return null;
            }

            var e = model;

            var data = new EmployeeParticipantsDto
            {
                Guid = e.Guid,
                EventGuid = e.EventGuid,
                EmployeeGuid = e.EmployeeGuid,
                IsJoin = e.IsJoin,
                IsPresent = e.IsPresent
            };

            return data;
        }

        public EmployeeParticipantsDto? Create(CreateEmployeeParticipantDto create)
        {
            var model = new EmployeeParticipant
            {
                Guid = new Guid(),
                EventGuid = create.EventGuid,
                EmployeeGuid = create.EmployeeGuid,
                IsJoin = create.IsJoin,
                IsPresent = create.IsPresent,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var created = _repository.Create(model);
            if (created is null)
            {
                return null;
            }


            var data = new EmployeeParticipantsDto
            {
                Guid = model.Guid,
                EventGuid = model.EventGuid,
                EmployeeGuid = model.EmployeeGuid,
                IsJoin = model.IsJoin,
                IsPresent = model.IsPresent
            };

            return data;
        }

        public EmployeeParticipantsDto? Update(EmployeeParticipantsDto update)
        {
            var single = _repository.GetByGuid(update.Guid);
            if (single == null)
            {
                return null;
            }

            var model = new EmployeeParticipant
            {
                Guid = update!.Guid,
                EventGuid = update!.EventGuid,
                EmployeeGuid = update!.EmployeeGuid,
                IsJoin = update!.IsJoin,
                IsPresent = update!.IsPresent
            };

            var isUpdate = _repository.Update(model);
            if (!isUpdate)
            {
                return null;
            }

            var data = new EmployeeParticipantsDto
            {
                Guid = model!.Guid,
                EventGuid = model!.EventGuid,
                EmployeeGuid = model!.EmployeeGuid,
                IsJoin = model!.IsJoin,
                IsPresent = model!.IsPresent
            };

            return data;
        }

        public EmployeeParticipantsDto? Delete(Guid guid)
        {
            var model = _repository.GetByGuid(guid);
            if (model == null)
            {
                return null;
            }

            var isDelete = _repository.Delete(model!);
            if (!isDelete)
            {
                return null;
            }

            var deleted = new EmployeeParticipantsDto
            {
                Guid = model!.Guid,
                EventGuid = model!.EventGuid,
                EmployeeGuid = model!.EmployeeGuid,
                IsJoin = model!.IsJoin,
                IsPresent = model!.IsPresent
            };

            return deleted;
        }
    }
}
