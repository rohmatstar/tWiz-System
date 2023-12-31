﻿using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;


[Table("pmdt_employees")]
public class Employee : BaseEntity
{
    [Column("nik", TypeName = "nvarchar(20)")]
    public string Nik { get; set; }

    [Column("full_name", TypeName = "nvarchar(100)")]
    public string FullName { get; set; }

    [Column("birthdate")]
    public DateTime BirthDate { get; set; }

    [Column("gender")]
    public GenderEnum Gender { get; set; }

    [Column("hiring_date")]
    public DateTime HiringDate { get; set; }

    [Column("phone_number", TypeName = "nvarchar(20)")]
    public string PhoneNumber { get; set; }

    [Column("company_guid")]
    public Guid CompanyGuid { get; set; }

    [Column("account_guid")]
    public Guid AccountGuid { get; set; }

    // Cardinality

    public ICollection<EmployeeParticipant>? EmployeeParticipants { get; set; }

    public Company? Company { get; set; }

    public Account? Account { get; set; }
}
