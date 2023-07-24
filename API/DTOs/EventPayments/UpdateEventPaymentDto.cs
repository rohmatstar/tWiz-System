﻿namespace API.DTOs.EventPayments;

public class UpdateEventPaymentDto
{
    public Guid Guid { get; set; }
    public Guid AccountGuid { get; set; }
    public int VaNumber { get; set; }
    public string PaymentImage { get; set; }
    public bool IsValid { get; set; }
    public Guid BankGuid { get; set; }
}
