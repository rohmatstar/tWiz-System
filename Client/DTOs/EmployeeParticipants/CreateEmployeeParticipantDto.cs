using Client.Utilities.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Client.DTOs.EmployeeParticipants
{
    public class CreateEmployeeParticipantDto
    {
        [Required]
        public Guid EventGuid { get; set; }

        [Required]
        public Guid EmployeeGuid { get; set; }

        [DefaultValue(InviteStatusLevel.Pending)]
        public InviteStatusLevel Status { get; set; }

        [DefaultValue(false)]
        public bool IsPresent { get; set; }
    }
}
