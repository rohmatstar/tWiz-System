using System.ComponentModel.DataAnnotations;

namespace API.DTOs.CompanyParticipants;

public class GetCompanyParticipantDto
{

    [Required]
    public Guid Guid { get; set; }

    public string? EventName { get; set; }

    [Required]
    public Guid CompanyGuid { get; set; }

    public string CompanyName { get; set; }

    public string InvitationStatus { get; set; }

    public bool IsPresent { get; set; }
}

