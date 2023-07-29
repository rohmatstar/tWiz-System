using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("pmtr_employee_participants")]
public class EmployeeParticipant : BaseEntity
{
    [Column("event_guid")]
    public Guid EventGuid { get; set; }

    [Column("employee_guid")]
    public Guid EmployeeGuid { get; set; }

    [Column("status")]
    public InviteStatusLevel Status { get; set; }

    [Column("is_present")]
    public bool IsPresent { get; set; }

    // Cardinality
    public Employee? Employee { get; set; }

    public Event? Event { get; set; }
}
