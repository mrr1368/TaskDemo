using System;
using System.ComponentModel.DataAnnotations;

namespace TaskDemo.ViewModel
{
    public class CreatePaymentRequestViewModel
    {
        [Display(Name = "تاریخ درخواست")]
        [Required(ErrorMessage = "تاریخ درخواست الزامی است.")]
        [RegularExpression(@"^\d{4}\/\d{2}\/\d{2}$", ErrorMessage = "فرمت تاریخ باید YYYY/MM/DD باشد")]
        public string RequestDate { get; set; }

        [Display(Name = "شماره فرم")]
        [Required(ErrorMessage = "شماره فرم الزامی است.")]
        public string FormNumber { get; set; }

        [Display(Name = "تعداد چک")]
        [Required(ErrorMessage = "تعداد چک الزامی میباشد")]
        [Range(1, 10, ErrorMessage = "تعداد چک باید بین ۱ تا ۱۰ باشد.")]
        public int CheckCount { get; set; }

        [Display(Name = "مبلغ (عدد)")]
        [Required(ErrorMessage = "مبلغ عددی الزامی است.")]
        [Range(1000, 100000000000, ErrorMessage = "مبلغ باید بین ۱,۰۰۰ تا ۱۰۰,۰۰۰,۰۰۰,۰۰۰ ریال باشد")]
        public decimal AmountNumeric { get; set; }

        [Display(Name = "تاریخ چک")]
        [RegularExpression(@"^\d{4}\/\d{2}\/\d{2}$", ErrorMessage = "فرمت تاریخ باید YYYY/MM/DD باشد")]
        [Required(ErrorMessage = "تاریخ چک الزامی است.")]
        public string CheckDate { get; set; }

        [Display(Name = "در وجه")]
        [Required(ErrorMessage = "نام ذی‌نفع الزامی است.")]
        public string RecipientName { get; set; }

        [Display(Name = "کد ملی / شناسه ملی")]
        [Required(ErrorMessage = "کد ملی یا شناسه ملی الزامی است.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "کد ملی باید ۱۰ رقمی باشد")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "کد ملی باید فقط شامل اعداد باشد")]
        public string NationalCode { get; set; }

        [Display(Name = "علت پرداخت")]
        [Required(ErrorMessage = "علت پرداخت الزامی است.")]
        public string PaymentReason { get; set; }

        [Display(Name = "شماره حساب")]
        [Required(ErrorMessage = "شماره حساب الزامی است.")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "شماره حساب باید ۱۶ رقمی باشد")]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "شماره حساب باید فقط شامل اعداد باشد")]
        public string AccountNumber { get; set; }

        [Display(Name = "بانک / شعبه")]
        [Required(ErrorMessage = "بانک و شعبه الزامی است.")]
        public string BankAndBranch { get; set; }

        [Display(Name = "شماره شِبا")]
        [Required(ErrorMessage = "شماره شِبا الزامی است.")]
        [RegularExpression(@"^IR\d{24}$", ErrorMessage = "شماره شِبا باید با IR شروع شده و ۲۴ رقم داشته باشد.")]
        public string ShebaNumber { get; set; }

        // ✅ فیلدهای تأیید و امضا

        [Display(Name = "اقدام‌کننده")]
        [Required(ErrorMessage = "نام اقدام‌کننده الزامی است.")]
        public string ActionBy { get; set; }

        [Display(Name = "مدیر واحد")]
        [Required(ErrorMessage = "نام مدیر واحد الزامی است.")]
        public string UnitManager { get; set; }

        [Display(Name = "مدیر مالی")]
        [Required(ErrorMessage = "نام مدیر مالی الزامی است.")]
        public string AccountingManager { get; set; }

        [Display(Name = "رئیس حسابداری")]
        [Required(ErrorMessage = "نام رئیس حسابداری الزامی است.")]
        public string ChiefAccountant { get; set; }

        [Display(Name = "مدیرعامل (تصویب‌کننده)")]
        [Required(ErrorMessage = "نام مدیرعامل الزامی است.")]
        public string CEOApproval { get; set; }
    }
}
