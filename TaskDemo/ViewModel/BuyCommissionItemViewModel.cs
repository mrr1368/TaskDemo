using System.ComponentModel.DataAnnotations;

namespace TaskDemo.ViewModels
{
    public class BuyCommissionItemViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "نام فروشنده الزامی است")]
        [MaxLength(100)]
        [Display(Name = "فروشنده/تامین‌کننده")]
        public string SellerName { get; set; }

        [Required(ErrorMessage = "مقدار الزامی است")]
        [Range(0.001, double.MaxValue, ErrorMessage = "مقدار باید بزرگتر از صفر باشد")]
        [Display(Name = "مقدار")]
        public decimal Quantity { get; set; }

        [Required(ErrorMessage = "قیمت واحد الزامی است")]
        [Range(0.01, double.MaxValue, ErrorMessage = "قیمت باید بزرگتر از صفر باشد")]
        [Display(Name = "قیمت واحد")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "جمع کل")]
        public decimal TotalPrice => Quantity * UnitPrice;

        [Required(ErrorMessage = "شرایط پرداخت الزامی است")]
        [MaxLength(50)]
        [Display(Name = "شرایط پرداخت")]
        public string PaymentTerms { get; set; }

        [Required(ErrorMessage = "گارانتی الزامی است")]
        [MaxLength(100)]
        [Display(Name = "گارانتی/سازنده")]
        public string WarrantyOrManufacturer { get; set; }

        [MaxLength(10)]
        [Display(Name = "زمان تحویل")]
        public string DeliveryTime { get; set; }

        [MaxLength(10)]
        [Display(Name = "تاریخ آخرین خرید")]
        public string LastPurchaseDate { get; set; }

        [Required(ErrorMessage = "کد کمیسیون الزامی است")]
        [Display(Name = "کد کمیسیون")]
        public int BuyCommissionHeaderId { get; set; }
    }
}
