using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.ProductHandling;
using SlothEnterprise.ProductApplication.ServiceResults;

namespace SlothEnterprise.ProductApplication
{
    public class ProductApplicationService
    {
        protected readonly IServiceHandlerDispatcher ServiceHandlerDispatcher;

        public ProductApplicationService(IServiceHandlerDispatcher serviceHandlerDispatcher)
        {
            ServiceHandlerDispatcher = serviceHandlerDispatcher;
        }

        // Comments.md - my remark about returning meaningful result/error object instead of int
        public ServiceResult SubmitApplicationFor(ISellerApplication application)
        {
            // Validate.IsNotNull(application); -> guard for param validation

            var serviceHandler = ServiceHandlerDispatcher.GetHandler(application.Product);
            return serviceHandler.SubmitApplicationFor(application);
        }
    }
}