using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;
using SlothEnterprise.ProductApplication.ServiceResults;

namespace SlothEnterprise.ProductApplication.ProductHandling
{
    public interface IProductHandler
    {
        bool CanHandle(IProduct product);
        ServiceResult SubmitApplicationFor(ISellerApplication application);
    }
}