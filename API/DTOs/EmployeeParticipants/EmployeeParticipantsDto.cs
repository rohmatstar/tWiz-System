using System.ComponentModel;
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

        [DefaultValue(false)]
        public bool IsJoin { get; set; }

        [DefaultValue(false)]
        public bool IsPresent { get; set; }
    }
}
