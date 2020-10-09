using System;
using SlothEnterprise.External;
using System.Collections.Generic;

namespace SlothEnterprise.ProductApplication.ServiceResults
{
    public class ServiceResult
    {
        public int? ApplicationId { get; set; }
        IList<ServiceError> Errors { get; set; }

        // A couple of overloads.
        // In real life scenario I would probably remove some of them or reuse them ( : base(args..))
        public ServiceResult(int applicationId)
        {
            ApplicationId = applicationId;
        }

        public ServiceResult(int id, int code, string errorMessage)
        {
            Errors.Add(new ServiceError
            {
                Id = id, 
                Code = code,
                Message = errorMessage,
                Timestamp = DateTime.UtcNow
            });
        }

        public ServiceResult(IApplicationResult applicationResult)
        {
            // ApplicationId should be null if result is NOT a success so the following check is definitely a code smell :-)
            ApplicationId = applicationResult.Success ? null : applicationResult.ApplicationId;

            //Errors = applicationResult.Errors etc.
            // It's not great we are only getting strings as errors here. Makes no sense to just pass them along.
            // We should be getting much more information about them. Now it would work just as proxy and it makes no sense to continue..
        }
    }
}