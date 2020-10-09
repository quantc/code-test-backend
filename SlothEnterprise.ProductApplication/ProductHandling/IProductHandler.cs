using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.ProductHandling
{
    public interface IProductHandler
    {
        bool CanHandle(IProduct product);
        int SubmitApplicationFor(ISellerApplication application);
    }
}