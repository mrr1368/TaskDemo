using Microsoft.EntityFrameworkCore;
using TaskDemo.Context;
using TaskDemo.Models;
using TaskDemo.Service.Interface;
using TaskDemo.ViewModel;
using TaskDemo.ViewModels;

namespace TaskDemo.Service.Implementation
{
    public class BuyCommissionService : IBuyCommissionService
    {
        private readonly ApplicationDbContext _context;

        public BuyCommissionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<BuyCommissionHeaderViewModel>> GetAllAsync()
        {
            return await _context.BuyCommissions
                .Include(bc => bc.Items)
                .Select(bc => new BuyCommissionHeaderViewModel
                {
                    Date = bc.Date,
                    Description = bc.Description,
                    DocumentNumberYear = bc.DocumentNumberYear, // توجه کن به اسم فیلد تو ویومدل
                    TotalQuantity = bc.TotalQuantity,
                    RequiredDate = bc.RequiredDate,
                    OptionAnalysis = bc.OptionAnalysis,
                    Notes = bc.Notes,
                    Items = bc.Items.Select(i => new BuyCommissionItemViewModel
                    {
                        Id = i.Id,
                        SellerName = i.SellerName,
                        Quantity = i.Quantity,
                        UnitPrice = i.UnitPrice,
                        PaymentTerms = i.PaymentTerms,
                        WarrantyOrManufacturer = i.WarrantyOrManufacturer,
                        DeliveryTime = i.DeliveryTime,
                        LastPurchaseDate = i.LastPurchaseDate
                    }).ToList()
                }).ToListAsync();
        }


        public async Task<bool> CreateAsync(BuyCommissionHeaderViewModel model)
        {
            try
            {
                var newCommission = new BuyCommissionHeader
                {
                    Date = model.Date,
                    Description = model.Description,
                    TotalQuantity = model.TotalQuantity,
                    RequiredDate = model.RequiredDate,
                    OptionAnalysis = model.OptionAnalysis,
                    Notes = model.Notes,
                    Items = model.Items.Select(i => new BuyCommissionItem
                    {
                        SellerName = i.SellerName,
                        Quantity = i.Quantity,
                        UnitPrice = i.UnitPrice,
                        PaymentTerms = i.PaymentTerms,
                        WarrantyOrManufacturer = i.WarrantyOrManufacturer,
                        DeliveryTime = i.DeliveryTime,
                        LastPurchaseDate = i.LastPurchaseDate,
                    }).ToList()
                };

                _context.BuyCommissions.Add(newCommission);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log error
                return false;
            }
        }

        public async Task<decimal> CalculateTotalPriceAsync(decimal quantity, decimal unitPrice)
        {
            return await Task.Run(() => quantity * unitPrice);
        }
    }
}

