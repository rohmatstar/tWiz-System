﻿using System.ComponentModel.DataAnnotations;

namespace API.DTOs.EmployeeParticipants;

public class GetEmployeeParticipantDto
{
    [Required]
    public Guid Guid { get; set; }

    public string EventName { get; set; }

    [Required]
    public Guid EmployeeGuid { get; set; }

    public string EmployeeName { get; set; }

    public string InvitationStatus { get; set; }

    public bool IsPresent { get; set; }
}

