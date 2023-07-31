using API.Utilities.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.CompanyParticipants;

public class CreateCompanyParticipantDto
{
    [Required]
    public Guid EventGuid { get; set; }

    [Required]
    public Guid CompanyGuid { get; set; }

    [DefaultValue(InviteStatusLevel.Pending)]
    public InviteStatusLevel Status { get; set; }

    [DefaultValue(false)]
    public bool IsPresent { get; set; }
}

