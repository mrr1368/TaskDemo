namespace TaskDemo.Service.Interface
{
    public interface IBuyCommissionService
    {
        Task<List<BuyCommissionHeaderViewModel>> GetAllAsync();
        Task<bool> CreateAsync(BuyCommissionHeaderViewModel model);
        // برای محاسبات خاص
        Task<decimal> CalculateTotalPriceAsync(decimal quantity, decimal unitPrice);
    }
}
