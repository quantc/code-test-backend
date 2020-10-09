using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.ProductHandling
{
    public class ProductHandlerDispatcher : IServiceHandlerDispatcher
    {
        private readonly IProductHandlerStore _productHandlerStore;

        public ProductHandlerDispatcher(IProductHandlerStore productHandlerStore)
        {
            _productHandlerStore = productHandlerStore;
        }

        public IProductHandler GetHandler(IProduct product)
        {
            foreach (var productHandler in _productHandlerStore.ProductHandlers)
            {
                if (productHandler.CanHandle(product))
                {
                    return productHandler;
                }
            }

            return new UnsupportedProductHandler();
        }
    }
}