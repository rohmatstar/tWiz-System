﻿namespace API.DTOs.EventPayments;

public class GetParticipantsPaidEventDto
{
    public Guid EventGuid { get; set; }
    public string EventName { get; set; }
    public Guid MakerGuid { get; set; }
    public string MakerName { get; set; }

    public List<GetEmployeeParticipantsPaidEventDto> EmployeeParticipantsPaidEvent { get; set; }
    public List<GetCompanyParticipantsPaidEventDto> CompanyParticipantsPaidEvent { get; set; }

}

