using System.ComponentModel.DataAnnotations;
using TaskDemo.ViewModel;
using TaskDemo.ViewModels;

public class BuyCommissionHeaderViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "تاریخ الزامی است")]
    [MaxLength(10, ErrorMessage = "فرمت تاریخ باید به صورت YYYY/MM/DD باشد")]
    [Display(Name = "تاریخ درخواست")]
    public string Date { get; set; }

    [Required(ErrorMessage = "شرح کار الزامی است")]
    [MaxLength(200, ErrorMessage = "شرح کار نمی‌تواند بیش از 200 کاراکتر باشد")]
    [Display(Name = "شرح درخواست")]
    public string Description { get; set; }

    [Required(ErrorMessage = "شماره سند الزامی است")]
    [MaxLength(50, ErrorMessage = "شماره سند نمی‌تواند بیش از 50 کاراکتر باشد")]
    [Display(Name = "شماره سند/سال")]
    public string DocumentNumberYear { get; set; }

    [Required(ErrorMessage = "مقدار مورد نیاز الزامی است")]
    [Range(0.001, double.MaxValue, ErrorMessage = "مقدار باید بزرگتر از صفر باشد")]
    [Display(Name = "مقدار کل")]
    public decimal TotalQuantity { get; set; }

    [Required(ErrorMessage = "تاریخ مورد نیاز الزامی است")]
    [MaxLength(10, ErrorMessage = "فرمت تاریخ باید به صورت YYYY/MM/DD باشد")]
    [Display(Name = "تاریخ مورد نیاز")]
    public string RequiredDate { get; set; }

    [MaxLength(500, ErrorMessage = "نظریه گزینه‌ای نمی‌تواند بیش از 500 کاراکتر باشد")]
    [Display(Name = "تحلیل گزینه‌ها")]
    public string OptionAnalysis { get; set; }

    [MaxLength(500, ErrorMessage = "توضیحات نمی‌تواند بیش از 500 کاراکتر باشد")]
    [Display(Name = "ملاحظات")]
    public string Notes { get; set; }

    [Display(Name = "آیتم‌های خرید")]
    public List<BuyCommissionItemViewModel> Items { get; set; } = new List<BuyCommissionItemViewModel>();
}