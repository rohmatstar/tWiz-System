using API.Utilities.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;


[Table ("pmdt_events")]
public class Event : BaseEntity
{
    [Column ("name", TypeName = "nvarchar(max)")]
    public string Name { get; set; }

    [Column("thumbnail", TypeName = "nvarchar(max)")]
    public string? Thumbnail { get; set; }

    [Column("description", TypeName = "text")]
    public string Description { get; set; }

    [Column ("is_published")]
    public bool IsPublished { get; set; }

    [Column("is_paid")]
    public bool IsPaid { get; set; }

    [Precision(10, 2)]
    [Column("price")]
    public decimal Price { get; set; }

    [Column("category", TypeName = "nvarchar(30)")]
    public string Category { get; set; }

    [Column ("status")]
    public EventStatus Status { get; set; }

    [Column("start_date")]
    public DateTime StartDate { get; set; }

    [Column("end_date")]
    public DateTime EndDate { get; set; }

    [Column("quota")]
    public int Quota { get; set; }

    [Column("place", TypeName = "nvarchar(50)")]
    public string Place { get; set; }

    [Column("created_by")]
    public Guid CreatedBy { get; set; }

    // Cardinality
    
    public  ICollection<EmployeeParticipant>? EmployeeParticipants { get; set; }
    public ICollection <CompanyParticipant>? CompanyParticipants { get; set; }

    public EventDoc? EventDoc { get; set; }

    public ICollection<EventPayment>? EventPayment { get; set; }
    public Company? Company { get; set; }
}
