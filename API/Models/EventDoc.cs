using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table ("pmtr_event_docs")]
public class EventDoc : BaseEntity
{
    [Column ("event_guid")]
    public Guid EventGuid { get; set; }

    [Column("documentation", TypeName = "text")]
    public string Documentation { get; set; }

    // Cardinality

    public Event? Event { get; set; }

}
