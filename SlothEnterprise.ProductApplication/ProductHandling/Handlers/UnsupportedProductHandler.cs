using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.ProductHandling
{
    public class UnsupportedProductHandler : IProductHandler
    {
        public bool CanHandle(IProduct product)
        {
            return true;
        }

        public int SubmitApplicationFor(ISellerApplication application)
        {
            // return -1 ONLY for backward compatibility.
            // Otherwise I would use new { result, exception = { id, status, msg, timestamp }} etc. object
            return -1;
        }
    }
}