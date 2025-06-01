using Microsoft.EntityFrameworkCore;

namespace TaskDemo.Models
{
    public class PaymentRequest
    {
        public int Id { get; set; } // شناسه یکتا

        public string RequestDate { get; set; } // تاریخ درخواست

        public string FormNumber { get; set; } // شماره فرم

        public int CheckCount { get; set; } // تعداد چک

        [Precision(18, 2)]
        public decimal AmountNumeric { get; set; } // مبلغ به عدد

        public string CheckDate { get; set; } // تاریخ چک

        public string RecipientName { get; set; } // نام ذی‌نفع

        public string NationalCode { get; set; } // کد ملی یا شناسه ملی

        public string PaymentReason { get; set; } // علت پرداخت

        public string AccountNumber { get; set; } // شماره حساب

        public string BankAndBranch { get; set; } // نام بانک و شعبه

        public string ShebaNumber { get; set; } // شماره شِبا (IR...)

        // فیلدهای تاییدیه / ثبت‌کننده
        public string ActionBy { get; set; }             // اقدام کننده
        public string UnitManager { get; set; }          // مدیر واحد
        public string AccountingManager { get; set; }    // مدیر مالی
        public string ChiefAccountant { get; set; }      // رئیس حسابداری
        public string CEOApproval { get; set; }          // مدیرعامل (تصویب‌کننده)
    }
}

