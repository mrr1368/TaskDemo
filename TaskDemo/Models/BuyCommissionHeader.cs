using Microsoft.EntityFrameworkCore;

namespace TaskDemo.Models
{
    public class BuyCommissionHeader
    {
        public int Id { get; set; }

        public string Date { get; set; } // مثال: "1403/02/21"

        public string Description { get; set; }

        public string DocumentNumberYear { get; set; }

        [Precision(18, 3)]
        public decimal TotalQuantity { get; set; }

        public string RequiredDate { get; set; }

        public string? OptionAnalysis { get; set; }

        public string? Notes { get; set; }

        public List<BuyCommissionItem> Items { get; set; } = new();
    }
}
