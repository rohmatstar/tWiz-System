using Client.Contracts;
using Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Client.Controllers
{
    public class PaymentController : Controller
    {

        private readonly ICompanyRepository _companyRepository;
        private readonly IAuthRepository _authRepository;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(ICompanyRepository companyRepository, IAuthRepository authRepository, IPaymentRepository paymentRepository)
        {
            _companyRepository = companyRepository;
            _authRepository = authRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task<IActionResult> PaymentRequired(string email)
        {
            var payment = await _paymentRepository.GetPaymentSummary(email);
            if (payment is not null)
            {
                TempData["payment"] = payment.Data;
                return View();
            }
            return RedirectToAction("InternalServerError", "Error");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}