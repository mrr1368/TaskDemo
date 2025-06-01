using Microsoft.EntityFrameworkCore;
using TaskDemo.Context;
using TaskDemo.Models;
using TaskDemo.Service.Interface;
using TaskDemo.ViewModel;

namespace TaskDemo.Service.Implementation
{
    public class PaymentRequestService : IPaymentRequestService
    {
        private readonly ApplicationDbContext _context;

        #region Constructor

        public PaymentRequestService(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Add

        public async Task<bool> AddAsync(CreatePaymentRequestViewModel model)
        {
            var entity = new PaymentRequest
            {
                RequestDate = model.RequestDate,
                FormNumber = model.FormNumber,
                CheckCount = model.CheckCount,
                AmountNumeric = model.AmountNumeric,
                CheckDate = model.CheckDate,
                RecipientName = model.RecipientName,
                NationalCode = model.NationalCode,
                PaymentReason = model.PaymentReason,
                AccountNumber = model.AccountNumber,
                BankAndBranch = model.BankAndBranch,
                ShebaNumber = model.ShebaNumber,
                ActionBy = model.ActionBy,
                UnitManager = model.UnitManager,
                AccountingManager = model.AccountingManager,
                ChiefAccountant = model.ChiefAccountant,
                CEOApproval = model.CEOApproval
            };

            _context.PaymentRequests.Add(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        #endregion

        #region GetAll

        public async Task<List<CreatePaymentRequestViewModel>> GetAllAsync()
        {
            return await _context.PaymentRequests
                .Select(p => new CreatePaymentRequestViewModel
                {
                    RequestDate = p.RequestDate,
                    FormNumber = p.FormNumber,
                    CheckCount = p.CheckCount,
                    AmountNumeric = p.AmountNumeric,
                    CheckDate = p.CheckDate,
                    RecipientName = p.RecipientName,
                    NationalCode = p.NationalCode,
                    PaymentReason = p.PaymentReason,
                    AccountNumber = p.AccountNumber,
                    BankAndBranch = p.BankAndBranch,
                    ShebaNumber = p.ShebaNumber,
                    ActionBy = p.ActionBy,
                    UnitManager = p.UnitManager,
                    AccountingManager = p.AccountingManager,
                    ChiefAccountant = p.ChiefAccountant,
                    CEOApproval = p.CEOApproval
                })
                .ToListAsync();
        }

        #endregion
    }
}
