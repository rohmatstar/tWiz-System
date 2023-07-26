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

        public bool IsJoin { get; set; }

        public bool IsPresent { get; set; }
    }
}
