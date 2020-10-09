using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.ProductHandling
{
    public class BaseServiceHandler<T> where T : IProduct
    {
        protected T Product;
    }
}