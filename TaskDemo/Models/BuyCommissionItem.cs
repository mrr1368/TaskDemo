using Microsoft.EntityFrameworkCore;

namespace TaskDemo.Models
{
    public class BuyCommissionItem
    {
        public int Id { get; set; }

        public string SellerName { get; set; }

        [Precision(18, 3)]
        public decimal Quantity { get; set; }

        [Precision(18, 4)]
        public decimal UnitPrice { get; set; }

        [Precision(18, 4)]
        public decimal TotalPrice { get; private set; }

        public string PaymentTerms { get; set; }

        public string WarrantyOrManufacturer { get; set; }

        public string? DeliveryTime { get; set; }

        public string? LastPurchaseDate { get; set; }

        public int BuyCommissionHeaderId { get; set; }

        public BuyCommissionHeader BuyCommissionHeader { get; set; }

        // تابع داخلی برای محاسبه مبلغ کل
        public void CalculateTotalPrice()
        {
            TotalPrice = Quantity * UnitPrice;
        }
    }
}
