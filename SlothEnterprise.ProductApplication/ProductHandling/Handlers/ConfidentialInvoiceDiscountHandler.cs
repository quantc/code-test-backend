using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.ProductHandling
{
    public class ConfidentialInvoiceDiscountHandler : BaseServiceHandler<ConfidentialInvoiceDiscount>, IProductHandler
    {
        // Register in DI module
        private readonly IConfidentialInvoiceService _confidentialInvoiceWebService;

        public ConfidentialInvoiceDiscountHandler(IConfidentialInvoiceService confidentialInvoiceWebService)
        {
            this._confidentialInvoiceWebService = confidentialInvoiceWebService;
        }

        public bool CanHandle(IProduct product)
        {
            return product is ConfidentialInvoiceDiscount;
        }

        public int SubmitApplicationFor(ISellerApplication application)
        {
            var result = _confidentialInvoiceWebService.SubmitApplicationFor(
                new CompanyDataRequest
                {
                    CompanyFounded = application.CompanyData.Founded,
                    CompanyNumber = application.CompanyData.Number,
                    CompanyName = application.CompanyData.Name,
                    DirectorName = application.CompanyData.DirectorName
                }, Product.TotalLedgerNetworth, Product.AdvancePercentage, Product.VatRate);

            return (result.Success) ? result.ApplicationId ?? -1 : -1;
        }
    }
}