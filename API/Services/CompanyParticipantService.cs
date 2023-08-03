using API.Contracts;
using API.DTOs.CompanyParticipants;
using API.Models;

namespace API.Services;

public class CompanyParticipantService
{
    private readonly ICompanyParticipantRepository _repository;

    public CompanyParticipantService(ICompanyParticipantRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<CompanyParticipantsDto>? GetCompanyParticipants()
    {
        var model = _repository.GetAll();

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
        var model = _repository.GetByGuid(guid);

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

        var created = _repository.Create(model);
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
        var single = _repository.GetByGuid(update.Guid);
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

        var isUpdate = _repository.Update(model);
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

    public int RemoveThenCreateCompanyParticipant(GetCompanyParticipantsDto companyParticipants)
    {

        return 1;
    }
}

