﻿using API.Contracts;
using API.Data;
using API.DTOs.EventPayments;
using API.Models;
using API.Utilities.Enums;
using API.Utilities.Handlers;
using API.Utilities.Validations;
using System.Security.Claims;

namespace API.Services;

public class EventPaymentService
{
    private readonly IEventPaymentRepository _eventPaymentRepository;
    private readonly IBankRepository _bankRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IEventRepository _eventRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly TwizDbContext _twizDbContext;
    private readonly AccountService _accountService;

    private readonly IEmailHandler _emailHandler;

    public EventPaymentService(IEventPaymentRepository eventPaymentRepository, IBankRepository bankRepository, ICompanyRepository companyRepository, IEmployeeRepository employeeRepository, IEventRepository eventRepository, IHttpContextAccessor httpContextAccessor, TwizDbContext twizDbContext, AccountService accountService, IEmailHandler emailHandler)
    {
        _eventPaymentRepository = eventPaymentRepository;
        _bankRepository = bankRepository;
        _companyRepository = companyRepository;
        _employeeRepository = employeeRepository;
        _eventRepository = eventRepository;
        _httpContextAccessor = httpContextAccessor;
        _twizDbContext = twizDbContext;
        _accountService = accountService;
        _emailHandler = emailHandler;
    }

    public IEnumerable<GetEventPaymentDto>? GetEventPayments()
    {
        var eventPayments = _eventPaymentRepository.GetAll();
        if (eventPayments is null)
        {
            return null; // No EventPayment Found
        }
        var toDto = eventPayments.Select(eventPayments => new GetEventPaymentDto
        {
            Guid = eventPayments.Guid,
            AccountGuid = eventPayments.AccountGuid,
            EventGuid = eventPayments.EventGuid,
            VaNumber = eventPayments.VaNumber,
            PaymentImage = eventPayments.PaymentImage,
            IsValid = eventPayments.IsValid,
            BankGuid = eventPayments.BankGuid,

        }).ToList();

        return toDto;
    }

    public GetEventPaymentDto? GetEventPayment(Guid guid)
    {
        var eventPayments = _eventPaymentRepository.GetByGuid(guid);
        if (eventPayments is null)
        {
            return null;
        }

        var eventName = _eventRepository.GetByGuid(eventPayments.EventGuid)?.Name;
        var bankName = _bankRepository.GetByGuid(eventPayments.BankGuid)?.Name;

        var statusPayment = "";

        if (eventPayments.StatusPayment == StatusPayment.Pending) statusPayment = "pending";
        if (eventPayments.StatusPayment == StatusPayment.Checking) statusPayment = "checking";
        if (eventPayments.StatusPayment == StatusPayment.Paid) statusPayment = "paid";
        if (eventPayments.StatusPayment == StatusPayment.Rejected) statusPayment = "rejected";


        var getEventPayment = new GetEventPaymentDto
        {
            Guid = eventPayments.Guid,
            AccountGuid = eventPayments.AccountGuid,
            EventGuid = eventPayments.EventGuid,
            VaNumber = eventPayments.VaNumber,
            PaymentImage = eventPayments.PaymentImage,
            IsValid = eventPayments.IsValid,
            BankGuid = eventPayments.BankGuid,
            BankName = bankName ?? "",
            EventName = eventName ?? "",
            StatusPayment = statusPayment ?? ""
        };

        var claimUser = _httpContextAccessor.HttpContext?.User;

        var userRole = claimUser?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        var accountGuid = claimUser?.Claims?.FirstOrDefault(x => x.Type == "Guid")?.Value;

        if (userRole == nameof(RoleLevel.Company))
        {
            var company = _companyRepository.GetAll().FirstOrDefault(c => c.AccountGuid == Guid.Parse(accountGuid!));

            if (company is null)
            {
                return null;
            }

            getEventPayment.AccountName = company.Name;
        }
        else if (userRole == nameof(RoleLevel.Employee))
        {
            var employee = _employeeRepository.GetAll().FirstOrDefault(c => c.AccountGuid == Guid.Parse(accountGuid!));

            if (employee is null)
            {
                return null;
            }

            getEventPayment.AccountName = employee.FullName;
        }
        else
        {
            return null;
        }

        return getEventPayment;

    }

    public GetEventPaymentDto? CreateEventPayment(CreateEventPaymentDto newEventPaymentDto)
    {
        var eventPayment = new EventPayment
        {
            Guid = new Guid(),
            AccountGuid = newEventPaymentDto.AccountGuid,
            EventGuid = newEventPaymentDto.EventGuid,
            VaNumber = newEventPaymentDto.VaNumber,
            PaymentImage = newEventPaymentDto.PaymentImage,
            IsValid = newEventPaymentDto.IsValid,
            BankGuid = newEventPaymentDto.BankGuid,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };

        var createdEventPayment = _eventPaymentRepository.Create(eventPayment);
        if (createdEventPayment is null)
        {
            return null; // EventPayment Not Created
        }

        var toDto = new GetEventPaymentDto
        {
            Guid = createdEventPayment.Guid,
            AccountGuid = createdEventPayment.AccountGuid,
            EventGuid = createdEventPayment.EventGuid,
            VaNumber = createdEventPayment.VaNumber,
            PaymentImage = createdEventPayment.PaymentImage,
            IsValid = createdEventPayment.IsValid,
            BankGuid = createdEventPayment.BankGuid,
        };

        return toDto; // EventPayment Created
    }

    public int UpdateEventPayment(UpdateEventPaymentDto UpdateEventPaymentDto)
    {
        var isExist = _eventPaymentRepository.IsExist(UpdateEventPaymentDto.Guid);
        if (!isExist)
        {
            return -1; // EventPayment Not Found
        }

        var getEventPayment = _eventPaymentRepository.GetByGuid(UpdateEventPaymentDto.Guid);

        var eventpayment = new EventPayment
        {
            Guid = UpdateEventPaymentDto.Guid,
            AccountGuid = UpdateEventPaymentDto.AccountGuid,
            EventGuid = UpdateEventPaymentDto.EventGuid,
            VaNumber = UpdateEventPaymentDto.VaNumber,
            PaymentImage = UpdateEventPaymentDto.PaymentImage,
            IsValid = UpdateEventPaymentDto.IsValid,
            BankGuid = UpdateEventPaymentDto.BankGuid,
            ModifiedDate = DateTime.Now,
            CreatedDate = getEventPayment!.CreatedDate
        };

        var isUpdate = _eventPaymentRepository.Update(eventpayment);
        if (!isUpdate)
        {
            return 0; // EventPayment Not Updated
        }
        return 1;
    }


    public int DeleteEventPayment(Guid guid)
    {
        var isExist = _eventPaymentRepository.IsExist(guid);
        if (!isExist)
        {
            return -1; // EventPayment Not Found
        }

        var eventpayment = _eventPaymentRepository.GetByGuid(guid);
        var isDelete = _eventPaymentRepository.Delete(eventpayment);
        if (!isDelete)
        {
            return 0; // EventPayment Not Deleted
        }

        return 1; // EventPayment Deleted
    }

    public async Task<int> UploadPaymentSubmission(EventPaymentSubmissionDto paymentSubmissionDto)
    {
        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\event_payments");

        if (!Directory.Exists(folderPath))
        {
            try
            {
                Directory.CreateDirectory(folderPath);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        var size = paymentSubmissionDto.PaymentImageFile.Length;

        // jika ukuran gambar lebih dari 2mb
        if (size > 2000000)
        {
            return -2;
        }

        bool isImage = FileValidation.IsValidImageExtension(paymentSubmissionDto.PaymentImageFile);

        if (!isImage)
        {
            return -3;
        }

        var eventPaymentByGuid = _eventPaymentRepository.GetByGuid(paymentSubmissionDto.Guid);
        var oldImageUrl = "";

        if (eventPaymentByGuid != null && eventPaymentByGuid.PaymentImage != "")
        {
            oldImageUrl = eventPaymentByGuid.PaymentImage;
        }


        var randomName = GenerateHandler.GenerateRandomString();
        var fileName = randomName + paymentSubmissionDto.PaymentImageFile.FileName;
        var imageUrl = $"images/event_payments/{fileName}";

        var filePath = $"{folderPath}\\{fileName}";
        using var transaction = _twizDbContext.Database.BeginTransaction();
        try
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await paymentSubmissionDto.PaymentImageFile.CopyToAsync(stream);
            }

            //// update payment image
            //bool paymentImageUpdated = _eventPaymentRepository.UpdatePaymentImage(paymentSubmissionDto.Guid, imageUrl);
            //if (!paymentImageUpdated)
            //{

            //    FileHandler.DeleteFileIfExist(filePath);
            //    return -4;
            //}

            //// update status payment
            //bool statusPaymentUpdated = _eventPaymentRepository.ChangeStatusEventPayment(paymentSubmissionDto.Guid, StatusPayment.Checking);

            //if (!statusPaymentUpdated)
            //{
            //    FileHandler.DeleteFileIfExist(filePath);
            //    return -5;
            //}

            eventPaymentByGuid!.PaymentImage = imageUrl;
            eventPaymentByGuid.StatusPayment = StatusPayment.Checking;
            bool updatedEventPayment = _eventPaymentRepository.Update(eventPaymentByGuid);

            if (updatedEventPayment == false)
            {
                return -5;
            }



            // hapus foto lama jika ada
            if (oldImageUrl != "")
            {
                var filePathOldImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", oldImageUrl.Replace("/", "\\"));
                FileHandler.DeleteFileIfExist(filePathOldImage);
            }
        }
        catch
        {
            transaction.Rollback();

            FileHandler.DeleteFileIfExist(filePath);
            return -4;
        }

        try
        {
            var contentEmail = $"" +
                $"<h1>Event Payment Submission</h1>" +
                $"<p>Participant Name : febri</p>" +
                $"<p>Virtual Account : {eventPaymentByGuid.VaNumber}</p>" +
                $"<p>Now you can check it</p>";

            var emailAdmin = _accountService.GetEmailSysAdmin();


            _emailHandler.SendEmail(_accountService.GetEmailSysAdmin(), "Event Payment Submission", contentEmail);
        }
        catch
        {
            FileHandler.DeleteFileIfExist(filePath);
            transaction.Rollback();
            return -6;
        }

        transaction.Commit();


        return 1;
    }
}
