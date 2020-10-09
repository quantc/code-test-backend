using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.ProductHandling.Handlers;
using System.Collections.Generic;

namespace SlothEnterprise.ProductApplication.ProductHandling
{
    /// <summary>
    /// Register this class in DI module with instances of ISelectInvoiceService, IConfidentialInvoiceService
    /// and IBusinessLoansService.
    /// IF ever a new service for a new type of product comes in, all we need is to
    /// - add it to the list of supported products here
    /// - add its handler
    /// </summary>
    public sealed class ProductHandlerStore : IProductHandlerStore
    {
        private readonly ISelectInvoiceService _selectInvoiceService;
        private readonly IConfidentialInvoiceService _confidentialInvoiceWebService;
        private readonly IBusinessLoansService _businessLoansService;

        public IReadOnlyCollection<IProductHandler> ProductHandlers { get; }

        public ProductHandlerStore(ISelectInvoiceService selectInvoiceService,
            IConfidentialInvoiceService confidentialInvoiceWebService, IBusinessLoansService businessLoansService)
        {
            _selectInvoiceService = selectInvoiceService;
            _confidentialInvoiceWebService = confidentialInvoiceWebService;
            _businessLoansService = businessLoansService;

            ProductHandlers = new List<IProductHandler>
            {
                new SelectiveInvoiceDiscountHandler(_selectInvoiceService),
                new ConfidentialInvoiceDiscountHandler(_confidentialInvoiceWebService),
                new BusinessLoansHandler(_businessLoansService)
            };
        }
    }
}