using Client.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Client.DTOs.CompanyParticipants;

public class CompanyParticipantsDto
{
    [Required]
    public Guid Guid { get; set; }

    [Required]
    public Guid EventGuid { get; set; }

    [Required]
    public Guid CompanyGuid { get; set; }

    public InviteStatusLevel Status { get; set; }

    public bool IsPresent { get; set; }
}

