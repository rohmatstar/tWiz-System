using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.EmployeeParticipants
{
    public class EmployeeParticipantsDto
    {
        [Required]
        public Guid Guid { get; set; }

        [Required]
        public Guid EventGuid { get; set; }

        [Required]
        public Guid EmployeeGuid { get; set; }

        public InviteStatusLevel Status { get; set; }

        public bool IsPresent { get; set; }
    }
}
