using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.ProductHandling
{
    public class BusinessLoansHandler : BaseServiceHandler<BusinessLoans>, IProductHandler
    {
        // Register in DI module
        private readonly IBusinessLoansService _businessLoansService;

        public BusinessLoansHandler(IBusinessLoansService businessLoansService)
        {
            this._businessLoansService = businessLoansService;
        }

        public bool CanHandle(IProduct product)
        {
            return product is ConfidentialInvoiceDiscount;
        }

        public int SubmitApplicationFor(ISellerApplication application)
        {
            var result = _businessLoansService.SubmitApplicationFor(new CompanyDataRequest
            {
                CompanyFounded = application.CompanyData.Founded,
                CompanyNumber = application.CompanyData.Number,
                CompanyName = application.CompanyData.Name,
                DirectorName = application.CompanyData.DirectorName
            }, new LoansRequest
            {
                InterestRatePerAnnum = Product.InterestRatePerAnnum,
                LoanAmount = Product.LoanAmount
            });
            return (result.Success) ? result.ApplicationId ?? -1 : -1;
        }
    }
}