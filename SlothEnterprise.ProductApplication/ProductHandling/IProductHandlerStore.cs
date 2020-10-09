using System.Collections.Generic;

namespace SlothEnterprise.ProductApplication.ProductHandling
{
    public interface IProductHandlerStore
    {
        IReadOnlyCollection<IProductHandler> ProductHandlers { get; }
    }
}