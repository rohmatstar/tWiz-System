using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table ("PMTR_EVENT_DOCS")]
public class EventDoc : BaseEntity
{
    [Column ("event_guid")]
    public Guid EventGuid { get; set; }

    [Column("documentation", TypeName = "text")]
    public string Documentation { get; set; }

    // Cardinality

    public Event? Event { get; set; }

}
