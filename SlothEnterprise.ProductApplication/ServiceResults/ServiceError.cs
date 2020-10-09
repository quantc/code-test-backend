using System;

namespace SlothEnterprise.ProductApplication.ServiceResults
{
    internal class ServiceError
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
    }
}