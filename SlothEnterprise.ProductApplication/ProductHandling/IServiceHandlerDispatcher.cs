using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.ProductHandling
{
    public interface IServiceHandlerDispatcher
    {
        IProductHandler GetHandler(IProduct product);
    }
}