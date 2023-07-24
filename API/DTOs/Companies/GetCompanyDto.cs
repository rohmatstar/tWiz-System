﻿namespace API.DTOs.Companies;

public class GetCompanyDto
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public Guid AccountGuid { get; set; }
}