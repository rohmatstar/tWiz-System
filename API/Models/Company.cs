﻿using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;


[Table ("PMDT_COMPANIES")]
public class Company : BaseEntity
{
    [Column ("name", TypeName = "nvarchar(100)" )]
    public string Name { get; set; }

    [Column("phone_number", TypeName = "nvarchar(20)")]
    public string PhoneNumber { get; set; }

    [Column("address", TypeName = "nvarchar(100)")]
    public string Address { get; set; }

    [Column("account_guid")]
    public Guid AccountGuid { get; set; }

    // Cardinality

    public RegisterPayment? RegisterPayment { get; set; }
    public Account? Account { get; set; }

    public CompanyParticipant? CompanyParticipant { get; set; }

    public ICollection<Event>? Events { get; set; }

    public ICollection<Employee>? Employees { get; set; }
}