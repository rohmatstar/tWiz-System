using API.Contracts;
using API.DTOs.CompanyParticipants;
using API.Models;
using API.Utilities.Enums;

namespace API.Services;

public class CompanyParticipantService
{
    private readonly ICompanyParticipantRepository _companyParticipantRepository;
    private readonly IEventRepository _eventRepository;
    private readonly ICompanyRepository _companyRepository;

    public CompanyParticipantService(ICompanyParticipantRepository repository, IEventRepository eventRepository, ICompanyRepository companyRepository)
    {
        _companyParticipantRepository = repository;
        _eventRepository = eventRepository;
        _companyRepository = companyRepository;
    }

    public IEnumerable<CompanyParticipantsDto>? GetCompanyParticipants()
    {
        var model = _companyParticipantRepository.GetAll();

        if (model is null)
        {
            return null;
        }

        var data = model.Select(e => new CompanyParticipantsDto
        {
            Guid = e.Guid,
            EventGuid = e.EventGuid,
            CompanyGuid = e.CompanyGuid,
            Status = e.Status,
            IsPresent = e.IsPresent
        }).ToList();

        return data;
    }

    public CompanyParticipantsDto? GetCompanyParticipant(Guid guid)
    {
        var model = _companyParticipantRepository.GetByGuid(guid);

        if (model is null)
        {
            return null;
        }

        var e = model;

        var data = new CompanyParticipantsDto
        {
            Guid = e.Guid,
            EventGuid = e.EventGuid,
            CompanyGuid = e.CompanyGuid,
            Status = e.Status,
            IsPresent = e.IsPresent
        };

        return data;
    }

    public CompanyParticipantsDto? CreateCompanyParticipant(CreateCompanyParticipantDto create)
    {
        var model = new CompanyParticipant
        {
            Guid = new Guid(),
            EventGuid = create.EventGuid,
            CompanyGuid = create.CompanyGuid,
            Status = create.Status,
            IsPresent = create.IsPresent
        };

        var created = _companyParticipantRepository.Create(model);
        if (created is null)
        {
            return null;
        }


        var data = new CompanyParticipantsDto
        {
            Guid = model.Guid,
            EventGuid = model.EventGuid,
            CompanyGuid = model.CompanyGuid,
            Status = model.Status,
            IsPresent = model.IsPresent
        };

        return data;
    }

    public CompanyParticipantsDto? UpdateCompanyParticipant(CompanyParticipantsDto update)
    {
        var single = _companyParticipantRepository.GetByGuid(update.Guid);
        if (single == null)
        {
            return null;
        }

        var model = new CompanyParticipant
        {
            Guid = update!.Guid,
            EventGuid = update!.EventGuid,
            CompanyGuid = update!.CompanyGuid,
            Status = update!.Status,
            IsPresent = update!.IsPresent
        };

        var isUpdate = _companyParticipantRepository.Update(model);
        if (!isUpdate)
        {
            return null;
        }

        var data = new CompanyParticipantsDto
        {
            Guid = model!.Guid,
            EventGuid = model!.EventGuid,
            CompanyGuid = model!.CompanyGuid,
            Status = model!.Status,
            IsPresent = model!.IsPresent
        };

        return data;
    }

    public CompanyParticipantsDto? DeleteCompanyParticipant(Guid guid)
    {
        var model = _companyParticipantRepository.GetByGuid(guid);
        if (model == null)
        {
            return null;
        }

        var isDelete = _companyParticipantRepository.Delete(model!);
        if (!isDelete)
        {
            return null;
        }

        var deleted = new CompanyParticipantsDto
        {
            Guid = model!.Guid,
            EventGuid = model!.EventGuid,
            CompanyGuid = model!.CompanyGuid,
            Status = model!.Status,
            IsPresent = model!.IsPresent
        };

        return deleted;
    }

    public int RemoveThenCreateCompanyParticipant(GetCompanyParticipantsDto companyParticipantsDto)
    {
        var companyParticipantsInEvent = _companyParticipantRepository.GetAll().Where(cp => cp.EventGuid == companyParticipantsDto.EventGuid).ToList();

        if (companyParticipantsInEvent.Count() == 0)
        {
            return 0;
        }

        var deletedCompanyParticipants = _companyParticipantRepository.Deletes(companyParticipantsInEvent);

        if (deletedCompanyParticipants == false)
        {
            return 0;
        }

        var companyParticipants = companyParticipantsDto.CompanyParticipantGuids.Select(cp =>
        {
            return new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = companyParticipantsDto.EventGuid,
                CompanyGuid = cp,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsPresent = false,
                Status = InviteStatusLevel.Pending
            };
        }).ToList();

        var createdCompanyParticipants = _companyParticipantRepository.Creates(companyParticipants);

        if (createdCompanyParticipants == false)
        {
            return 0;
        }

        return 1;
    }

    public List<GetCompanyParticipantDto>? GetCompanyParticipantsByEvent(Guid eventGuid)
    {
        var getEvent = _eventRepository.GetByGuid(eventGuid);

        if (getEvent == null)
        {
            return null;
        }

        var companies = _companyRepository.GetAll();

        var companyParticipants = _companyParticipantRepository.GetAll().Where(cp => cp.EventGuid == eventGuid && cp.CompanyGuid != getEvent.CreatedBy).Select(cp =>
        {
            var company = companies.FirstOrDefault(c => c.Guid == cp.CompanyGuid);

            var invitationStatus = "";

            if (cp.Status == InviteStatusLevel.Pending) invitationStatus = "pending";
            if (cp.Status == InviteStatusLevel.Checking) invitationStatus = "checking";
            if (cp.Status == InviteStatusLevel.Accepted) invitationStatus = "accepted";
            if (cp.Status == InviteStatusLevel.Rejected) invitationStatus = "rejected";


            return new GetCompanyParticipantDto
            {
                Guid = cp.Guid,
                EventName = getEvent.Name,
                CompanyGuid = cp.CompanyGuid,
                CompanyName = company.Name,
                InvitationStatus = invitationStatus ?? "",
                IsPresent = cp.IsPresent
            };
        }).ToList();

        if (companyParticipants is null)
        {
            return null;
        }

        return companyParticipants;
    }


}

