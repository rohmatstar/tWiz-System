using System.ComponentModel.DataAnnotations;

namespace API.DTOs.CompanyParticipants;

public class CompanyParticipantsDto
{
    [Required]
    public Guid Guid { get; set; }

    [Required]
    public Guid EventGuid { get; set; }

    [Required]
    public Guid CompanyGuid { get; set; }

    public bool IsJoin { get; set; }

    public bool IsPresent { get; set; }
}

