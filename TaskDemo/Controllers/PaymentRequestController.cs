using Microsoft.AspNetCore.Mvc;
using TaskDemo.Service.Interface;
using TaskDemo.ViewModel;

namespace TaskDemo.Controllers
{
    public class PaymentRequestController : Controller
    {
        private readonly IPaymentRequestService _paymentRequestService;

        #region Constructor

        public PaymentRequestController(IPaymentRequestService paymentRequestService)
        {
            _paymentRequestService = paymentRequestService;
        }

        #endregion

        #region Create (GET)

        // نمایش فرم ثبت درخواست وجه
        [HttpGet("/payment-create")]
        public IActionResult Create()
        {
            return View();
        }

        #endregion

        #region Create (POST)

        // ثبت اطلاعات فرم در دیتابیس
        [HttpPost("/payment-create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePaymentRequestViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var success = await _paymentRequestService.AddAsync(model);

            if (success)
                return RedirectToAction(nameof(List));

            ModelState.AddModelError("", "خطا در ثبت اطلاعات. لطفاً دوباره تلاش کنید.");
            return View(model);
        }

        #endregion

        #region List

        // نمایش لیست درخواست‌های ثبت‌شده
        [HttpGet("/payment-list")]
        public async Task<IActionResult> List()
        {
            var result = await _paymentRequestService.GetAllAsync();
            return View(result);
        }

        #endregion
    }
}
