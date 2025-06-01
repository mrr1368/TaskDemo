using TaskDemo.ViewModel;

namespace TaskDemo.Service.Interface
{
    public interface IPaymentRequestService
    {

        // دریافت لیست تمام درخواست‌ها
        Task<List<CreatePaymentRequestViewModel>> GetAllAsync();


        // افزودن درخواست جدید و برگرداندن موفقیت/شکست
        Task<bool> AddAsync(CreatePaymentRequestViewModel model);
    }
}
