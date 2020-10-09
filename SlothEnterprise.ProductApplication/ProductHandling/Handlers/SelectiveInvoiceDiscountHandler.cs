using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.ProductHandling.Handlers
{
    public sealed class SelectiveInvoiceDiscountHandler : BaseServiceHandler<SelectiveInvoiceDiscount>, IProductHandler
    {
        // Register in DI module
        private readonly ISelectInvoiceService selectInvoiceService;

        public SelectiveInvoiceDiscountHandler(ISelectInvoiceService selectInvoiceService)
        {
            this.selectInvoiceService = selectInvoiceService;
        }

        public bool CanHandle(IProduct product)
        {
            return product is SelectiveInvoiceDiscount;
        }

        public int SubmitApplicationFor(ISellerApplication application)
        {
            return selectInvoiceService.SubmitApplicationFor(
                application.CompanyData.Number.ToString(),
                Product.InvoiceAmount,
                Product.AdvancePercentage);
        }
    }
}
