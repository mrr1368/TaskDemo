using Microsoft.AspNetCore.Mvc;
using TaskDemo.Service.Interface;
using TaskDemo.ViewModel;

namespace TaskDemo.Controllers
{
    public class BuyCommissionController : Controller
    {
        private readonly IBuyCommissionService _buyCommissionService;

        #region Constructor

        public BuyCommissionController(IBuyCommissionService buyCommissionService)
        {
            _buyCommissionService = buyCommissionService;
        }

        #endregion

        #region Create (GET)

        // نمایش فرم ثبت کمیسیون خرید
        [HttpGet("/buycommission-create")]
        public IActionResult Create()
        {
            var model = new BuyCommissionHeaderViewModel();

            // ایجاد ۳ آیتم پیش‌فرض برای فرم
            for (int i = 0; i < 3; i++)
            {
                model.Items.Add(new ViewModels.BuyCommissionItemViewModel());
            }

            return View(model);
        }

        #endregion

        #region Create (POST)

        // ثبت کمیسیون خرید در دیتابیس
        [HttpPost("/buycommission-create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BuyCommissionHeaderViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var success = await _buyCommissionService.CreateAsync(model);

            if (success)
                return RedirectToAction(nameof(List));

            ModelState.AddModelError("", "خطا در ثبت اطلاعات. لطفاً دوباره تلاش کنید.");
            return View(model);
        }

        #endregion

        #region List

        // نمایش لیست کمیسیون‌های ثبت‌شده
        [HttpGet("/buycommission-list")]
        public async Task<IActionResult> List()
        {
            var result = await _buyCommissionService.GetAllAsync();
            return View(result);
        }

        #endregion
    }
}
