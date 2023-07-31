using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("pmtr_company_participants")]
public class CompanyParticipant : BaseEntity
{
    [Column("event_guid")]
    public Guid EventGuid { get; set; }

    [Column("company_guid")]
    public Guid CompanyGuid { get; set; }

    [Column("status")]
    public InviteStatusLevel Status { get; set; }

    [Column("is_present")]
    public bool IsPresent { get; set; }

    // Cardinality

    public Company? Company { get; set; }

    public Event? Event { get; set; }

}
