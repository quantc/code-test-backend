using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;
using SlothEnterprise.ProductApplication.ServiceResults;

namespace SlothEnterprise.ProductApplication.ProductHandling.Handlers
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

        /// <summary>
        /// Returning ServiceResult instead of int -> no backwards compatibility, doing that on purpose. It's something (more information) for something (backwards compatibility) :)
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public ServiceResult SubmitApplicationFor(ISellerApplication application)
        {
            var result = _confidentialInvoiceWebService.SubmitApplicationFor(
                new CompanyDataRequest
                {
                    CompanyFounded = application.CompanyData.Founded,
                    CompanyNumber = application.CompanyData.Number,
                    CompanyName = application.CompanyData.Name,
                    DirectorName = application.CompanyData.DirectorName
                }, Product.TotalLedgerNetworth, Product.AdvancePercentage, Product.VatRate);

            return new ServiceResult(result);
        }
    }
}