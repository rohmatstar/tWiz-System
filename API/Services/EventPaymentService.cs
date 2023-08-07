using API.Contracts;
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
    private readonly IAccountRepository _accountRepository;
    private readonly ICompanyParticipantRepository _companyParticipantRepository;
    private readonly IEmployeeParticipantRepository _employeeParticipantRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly TwizDbContext _twizDbContext;
    private readonly AccountService _accountService;

    private readonly IEmailHandler _emailHandler;

    public EventPaymentService(IEventPaymentRepository eventPaymentRepository, IBankRepository bankRepository, ICompanyRepository companyRepository, IEmployeeRepository employeeRepository, IEventRepository eventRepository, IHttpContextAccessor httpContextAccessor, TwizDbContext twizDbContext, AccountService accountService, IEmailHandler emailHandler, ICompanyParticipantRepository companyParticipantRepository, IEmployeeParticipantRepository employeeParticipantRepository, IAccountRepository accountRepository)
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
        _companyParticipantRepository = companyParticipantRepository;
        _employeeParticipantRepository = employeeParticipantRepository;
        _accountRepository = accountRepository;
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
        else if (userRole == nameof(RoleLevel.SysAdmin)) { }
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
            PaymentImage = newEventPaymentDto.PaymentImage ?? "",
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

    public async Task<int> UploadEventPaymentSubmission(EventPaymentSubmissionDto paymentSubmissionDto)
    {
        var claimUser = _httpContextAccessor.HttpContext?.User;

        var userRole = claimUser?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        var accountGuid = claimUser?.Claims?.FirstOrDefault(x => x.Type == "Guid")?.Value;
        var accountName = "";

        if (paymentSubmissionDto.PaymentImageFile is null)
        {
            return -8;
        }

        if (accountGuid == null)
        {
            return 0;
        }

        var account = _accountRepository.GetByGuid(Guid.Parse(accountGuid));

        if (account == null)
        {
            return 0;
        }

        var eventPaymentByGuid = _eventPaymentRepository.GetByGuid(paymentSubmissionDto.Guid);

        if (eventPaymentByGuid is null)
        {
            return -7;
        }

        var getEvent = _eventRepository.GetByGuid(eventPaymentByGuid.EventGuid);

        if (getEvent is null)
        {
            return -7;
        }

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

            eventPaymentByGuid!.PaymentImage = imageUrl;
            eventPaymentByGuid.StatusPayment = StatusPayment.Checking;
            eventPaymentByGuid.IsValid = false;
            bool updatedEventPayment = _eventPaymentRepository.Update(eventPaymentByGuid);

            if (updatedEventPayment == false)
            {
                FileHandler.DeleteFileIfExist(filePath);
                return -5;
            }



            // hapus foto lama jika ada
            if (oldImageUrl != "")
            {
                var filePathOldImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", oldImageUrl.Replace("/", "\\"));
                FileHandler.DeleteFileIfExist(filePathOldImage);
            }

            if (userRole == nameof(RoleLevel.Company))
            {
                var company = _companyRepository.GetAll().FirstOrDefault(c => c.AccountGuid == account.Guid);

                if (company is null)
                {
                    FileHandler.DeleteFileIfExist(filePath);
                    return -7;
                }

                accountName = company.Name;

                var companyParticipant = _companyParticipantRepository.GetAll().FirstOrDefault(cp => cp.CompanyGuid == company.Guid && cp.EventGuid == getEvent.Guid);

                if (companyParticipant is null)
                {
                    FileHandler.DeleteFileIfExist(filePath);
                    return 0;
                }

                companyParticipant.Status = InviteStatusLevel.Checking;

                var updatedCompanyParticipant = _companyParticipantRepository.Update(companyParticipant);

                if (updatedCompanyParticipant is false)
                {
                    FileHandler.DeleteFileIfExist(filePath);
                    return 0;
                }
            }
            else if (userRole == nameof(RoleLevel.Employee))
            {
                var employee = _employeeRepository.GetAll().FirstOrDefault(c => c.AccountGuid == account.Guid);

                if (employee is null)
                {
                    FileHandler.DeleteFileIfExist(filePath);
                    return 0;
                }

                accountName = employee.FullName;

                var employeeParticipant = _employeeParticipantRepository.GetAll().FirstOrDefault(ep => ep.EmployeeGuid == employee.Guid && ep.EventGuid == getEvent.Guid);

                if (employeeParticipant is null)
                {
                    FileHandler.DeleteFileIfExist(filePath);
                    return 0;
                }

                employeeParticipant.Status = InviteStatusLevel.Checking;

                var updatedEmployeeParticipant = _employeeParticipantRepository.Update(employeeParticipant);

                if (updatedEmployeeParticipant is false)
                {
                    FileHandler.DeleteFileIfExist(filePath);
                    return 0;
                }
            }
            else
            {
                transaction.Rollback();

                FileHandler.DeleteFileIfExist(filePath);
                return -4;
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
                $"<p>Participant Name : {accountName}</p>" +
                $"<p>Virtual Account : {eventPaymentByGuid.VaNumber}</p>" +
                $"<p>Now you can check it</p>";

            var eventMaker = _companyRepository.GetByGuid(getEvent.CreatedBy);

            if (eventMaker is null)
            {
                FileHandler.DeleteFileIfExist(filePath);
                return -7;
            }

            var emailEventMaker = _accountRepository.GetByGuid(eventMaker.AccountGuid)?.Email ?? null;

            if (emailEventMaker is null)
            {
                FileHandler.DeleteFileIfExist(filePath);
                return -7;
            }


            _emailHandler.SendEmail(emailEventMaker, "Event Payment Submission", contentEmail);
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

    public int ValidationEventPayment(AproveEventPaymentDto aproveEventPaymentDto, string status)
    {
        var getEventPayment = _eventPaymentRepository.GetByGuid(aproveEventPaymentDto.Guid);

        if (getEventPayment == null)
        {
            return 0;
        }
        var getEvent = _eventRepository.GetByGuid(getEventPayment.EventGuid);

        if (getEvent is null)
        {
            return 0;
        }

        var account = _accountRepository.GetByGuid(getEventPayment.AccountGuid);

        if (account is null)
        {
            return 0;
        }

        var company = _companyRepository.GetAll().FirstOrDefault(c => c.AccountGuid == account.Guid);
        var employee = _employeeRepository.GetAll().FirstOrDefault(e => e.AccountGuid == account.Guid);
        using var transaction = _twizDbContext.Database.BeginTransaction();

        // check who owns the account (company or employee)
        if (company is not null)
        {
            var companyParticipant = _companyParticipantRepository.GetAll().FirstOrDefault(cp => cp.CompanyGuid == company.Guid && cp.EventGuid == getEvent.Guid);

            if (companyParticipant is null)
            {
                return 0;
            }
            if (status == "approve")
            {
                companyParticipant.Status = InviteStatusLevel.Accepted;
            }
            else
            {
                companyParticipant.Status = InviteStatusLevel.Rejected;
            }

            var updatedCompanyParticipant = _companyParticipantRepository.Update(companyParticipant);

            if (updatedCompanyParticipant is false)
            {
                return 0;
            }
        }
        else if (employee is not null)
        {
            var employeeParticipant = _employeeParticipantRepository.GetAll().FirstOrDefault(cp => cp.EmployeeGuid == employee.Guid && cp.EventGuid == getEvent.Guid);

            if (employeeParticipant is null)
            {
                return 0;
            }

            if (status == "approve")
            {
                employeeParticipant.Status = InviteStatusLevel.Accepted;
            }
            else
            {
                employeeParticipant.Status = InviteStatusLevel.Rejected;
            }

            var updatedCompanyParticipant = _employeeParticipantRepository.Update(employeeParticipant);

            if (updatedCompanyParticipant is false)
            {
                return 0;
            }
        }
        else
        {
            return 0;
        }

        if (status == "approve")
        {
            getEventPayment.IsValid = true;
            getEventPayment.StatusPayment = StatusPayment.Paid;
            getEventPayment.ModifiedDate = DateTime.Now;
        }
        else
        {
            getEventPayment.IsValid = false;
            getEventPayment.StatusPayment = StatusPayment.Rejected;
            getEventPayment.ModifiedDate = DateTime.Now;
        }


        var eventPaymentUpdated = _eventPaymentRepository.Update(getEventPayment);

        if (eventPaymentUpdated is false)
        {
            transaction.Rollback();
            return 0;
        }

        //try
        //{
        //    var contentEmail = "";

        //    if (status == "approve")
        //    {
        //        contentEmail = $"<h1>Congratulation Your Event Payment Submission Has Been Verified</h1>" +
        //                        $"<h2>{getEvent.Name.ToUpper()}</h2>" +
        //                        $"<p>{getEvent.Description}</p>" +
        //                        $"<p>{getEvent.StartDate}</p>" +
        //                        $"<p>{getEvent.EndDate} </p>"
        //                        ;
        //    }
        //    else
        //    {
        //        contentEmail = "<h1>Your Event Payment Submission is Not Valid</h1>" +
        //                        $"<p>please re-upload the correct proof of payment</p>";
        //    }

        //    _emailHandler.SendEmail(account.Email, "Aproved event payment submission", contentEmail);

        //    transaction.Commit();
        //}
        //catch
        //{
        //    transaction.Rollback();
        //    return 0;
        //}
        transaction.Commit();
        return 1;
    }

    public EventPaymentSummaryDto? GetPaymentSummary(Guid guid)
    {

        var eventPayment = _eventPaymentRepository.GetAll().FirstOrDefault(ep => ep.Guid == guid);
        if (eventPayment is null)
        {
            return null;
        }
        var bank = _bankRepository.GetAll().FirstOrDefault(b => b.Guid == eventPayment.BankGuid);
        if (bank is null)
        {
            return null;
        }

        var getEvent = _eventRepository.GetByGuid(eventPayment.EventGuid);

        if (getEvent is null)
        {
            return null;
        }

        var getEventMaker = _companyRepository.GetByGuid(getEvent.CreatedBy);

        if (getEventMaker is null)
        {
            return null;
        }

        var paymentStatus = "";

        if (eventPayment.StatusPayment == StatusPayment.Pending) paymentStatus = "pending";
        if (eventPayment.StatusPayment == StatusPayment.Checking) paymentStatus = "checking";
        if (eventPayment.StatusPayment == StatusPayment.Rejected) paymentStatus = "rejected";
        if (eventPayment.StatusPayment == StatusPayment.Paid) paymentStatus = "paid";

        if (eventPayment.StatusPayment == StatusPayment.Paid)
        {
            var paid = new EventPaymentSummaryDto
            {
                Guid = eventPayment.Guid,
                VaNumber = 0,
                Price = 0,
                BankCode = null,
                BankName = null,
                CompanyName = getEventMaker.Name,
                PaymentStatus = paymentStatus,
            };
            return paid;
        }

        var toDto = new EventPaymentSummaryDto
        {
            Guid = eventPayment.Guid,
            VaNumber = eventPayment.VaNumber,
            Price = getEvent.Price,
            BankCode = bank.Code,
            BankName = bank.Name,
            CompanyName = getEventMaker.Name,
            PaymentStatus = paymentStatus,

        };
        return toDto;
    }

    public GetParticipantsPaidEventDto? GetParticipantsPaidEvent(Guid eventGuid)
    {
        var getEvent = _eventRepository.GetByGuid(eventGuid);
        if (getEvent.IsPaid == false)
        {
            return null;
        }


        var companies = _companyRepository.GetAll();
        var employees = _employeeRepository.GetAll();
        var eventPayments = _eventPaymentRepository.GetAll();

        var participantsPaidEvent = new GetParticipantsPaidEventDto();

        participantsPaidEvent.EventGuid = eventGuid;


        if (getEvent is null)
        {
            return null;
        }

        participantsPaidEvent.EventName = getEvent.Name;

        var makerEvent = companies.FirstOrDefault(c => c.Guid == getEvent.CreatedBy);

        participantsPaidEvent.MakerGuid = makerEvent.Guid;
        participantsPaidEvent.MakerName = makerEvent.Name;

        // setup company participants paid event ==>
        var filterCompanyParticipants = _companyParticipantRepository.GetAll().Where(cp => cp.EventGuid == eventGuid);

        if (filterCompanyParticipants is null)
        {
            return null;
        }

        var companyParticipantsPaidEvent = filterCompanyParticipants.Select(cp =>
        {
            var company = companies.FirstOrDefault(c => c.Guid == cp.CompanyGuid);

            var companyEventPayment = eventPayments.FirstOrDefault(evp => evp.EventGuid == eventGuid && evp.AccountGuid == company.AccountGuid);

            var invitationStatus = "";

            if (cp.Status == InviteStatusLevel.Pending) invitationStatus = "pending";
            if (cp.Status == InviteStatusLevel.Accepted) invitationStatus = "accepted";
            if (cp.Status == InviteStatusLevel.Rejected) invitationStatus = "rejected";
            if (cp.Status == InviteStatusLevel.Checking) invitationStatus = "checking";

            return new GetCompanyParticipantsPaidEventDto
            {
                ParticipantGuid = cp.Guid,
                EventName = getEvent.Name,
                CompanyGuid = company.Guid,
                CompanyName = company.Name,
                InvitationStatus = invitationStatus,
                IsPresent = cp.IsPresent,
                PaymentImageUrl = companyEventPayment?.PaymentImage ?? "",
                EventPaymentGuid = companyEventPayment?.Guid
            };
        }).ToList();
        // <==

        participantsPaidEvent.CompanyParticipantsPaidEvent = companyParticipantsPaidEvent;

        // setup employee participants paid event ==>
        var filterEmployeeParticipants = _employeeParticipantRepository.GetAll().Where(cp => cp.EventGuid == eventGuid);

        if (filterEmployeeParticipants is null)
        {
            return null;
        }

        var employeeParticipantsPaidEvent = filterEmployeeParticipants.Select(ep =>
        {
            var employee = employees.FirstOrDefault(e => e.Guid == ep.EmployeeGuid);

            var companyEmployee = companies.FirstOrDefault(c => c.Guid == employee.CompanyGuid);

            var employeeEventPayment = eventPayments.FirstOrDefault(evp => evp.EventGuid == eventGuid && evp.AccountGuid == employee.AccountGuid);

            var invitationStatus = "";

            if (ep.Status == InviteStatusLevel.Pending) invitationStatus = "pending";
            if (ep.Status == InviteStatusLevel.Accepted) invitationStatus = "accepted";
            if (ep.Status == InviteStatusLevel.Rejected) invitationStatus = "rejected";
            if (ep.Status == InviteStatusLevel.Checking) invitationStatus = "checking";

            return new GetEmployeeParticipantsPaidEventDto
            {
                ParticipantGuid = ep.Guid,
                EventName = getEvent.Name,
                EmployeeGuid = employee.Guid,
                EmployeeName = employee.FullName,
                InvitationStatus = invitationStatus,
                IsPresent = ep.IsPresent,
                PaymentImageUrl = employeeEventPayment?.PaymentImage ?? "",
                EventPaymentGuid = employeeEventPayment?.Guid,
                CompanyName = companyEmployee.Name,

            };
        }).ToList();

        // <==

        participantsPaidEvent.EmployeeParticipantsPaidEvent = employeeParticipantsPaidEvent;

        return participantsPaidEvent;
    }
}
