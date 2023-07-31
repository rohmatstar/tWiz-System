using System.ComponentModel.DataAnnotations;

namespace API.DTOs.EmployeeParticipants;

public class UpdateEmployeParticipantsDto
{
    [Required]
    public Guid EventGuid { get; set; }

    [Required]
    public List<Guid>? EmployeesGuids { get; set; }
}

