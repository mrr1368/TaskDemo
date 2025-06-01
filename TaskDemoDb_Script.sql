/* =============================================

ساختار دیتابیس فرم‌های خرید:

- جدول اصلی کمیسیون‌ها
- آیتم‌های کمیسیون مرتبط با هر درخواست
- درخواست‌های وجه/صدور چک
- ایندکس‌ها و روابط کلیدی

============================================= */

-- جدول کمیسیون‌های خرید
CREATE TABLE dbo.BuyCommissions (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Date NVARCHAR(MAX) NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    DocumentNumberYear NVARCHAR(MAX) NOT NULL,
    TotalQuantity DECIMAL(18, 3) NOT NULL,
    RequiredDate NVARCHAR(MAX) NOT NULL,
    OptionAnalysis NVARCHAR(MAX),
    Notes NVARCHAR(MAX)
);
GO

-- جدول آیتم‌های مربوط به کمیسیون‌ها
CREATE TABLE dbo.BuyCommissionItems (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    SellerName NVARCHAR(MAX) NOT NULL,
    Quantity DECIMAL(18, 3) NOT NULL,
    UnitPrice DECIMAL(18, 4) NOT NULL,
    TotalPrice DECIMAL(18, 4) NOT NULL,
    PaymentTerms NVARCHAR(MAX) NOT NULL,
    WarrantyOrManufacturer NVARCHAR(MAX) NOT NULL,
    DeliveryTime NVARCHAR(MAX),
    LastPurchaseDate NVARCHAR(MAX),
    BuyCommissionHeaderId INT NOT NULL
);
GO

-- جدول درخواست‌های پرداخت و صدور چک
CREATE TABLE dbo.PaymentRequests (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    RequestDate NVARCHAR(MAX) NOT NULL,
    FormNumber NVARCHAR(MAX) NOT NULL,
    CheckCount INT NOT NULL,
    AmountNumeric DECIMAL(18, 2) NOT NULL,
    CheckDate NVARCHAR(MAX) NOT NULL,
    RecipientName NVARCHAR(MAX) NOT NULL,
    NationalCode NVARCHAR(MAX) NOT NULL,
    PaymentReason NVARCHAR(MAX) NOT NULL,
    AccountNumber NVARCHAR(MAX) NOT NULL,
    BankAndBranch NVARCHAR(MAX) NOT NULL,
    ShebaNumber NVARCHAR(MAX) NOT NULL,
    ActionBy NVARCHAR(MAX) NOT NULL,
    UnitManager NVARCHAR(MAX) NOT NULL,
    AccountingManager NVARCHAR(MAX) NOT NULL,
    ChiefAccountant NVARCHAR(MAX) NOT NULL,
    CEOApproval NVARCHAR(MAX) NOT NULL
);
GO

-- ایندکس و رابطه بین آیتم‌ها و جدول کمیسیون
CREATE INDEX IX_BuyCommissionItems_BuyCommissionHeaderId
ON dbo.BuyCommissionItems (BuyCommissionHeaderId);
GO

ALTER TABLE dbo.BuyCommissionItems
ADD CONSTRAINT FK_BuyCommissionItems_BuyCommissions_BuyCommissionHeaderId
FOREIGN KEY (BuyCommissionHeaderId)
REFERENCES dbo.BuyCommissions (Id)
ON DELETE CASCADE;
GO
