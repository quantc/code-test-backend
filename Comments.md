Areas for concern:

1. So, first of all let's have a look at ProductApplicationService and ask a question - what if another type of product comes in and with it a new microservice? Another "if" inside the ProductApplicationService? Obviously not, there has to be a strategy pattern involved. 
This got implemented although I found "Dispatcher" naming a bit more appropriate.

2 Return values
2.1 "return (result.Success) ? result.ApplicationId ?? -1 : -1;" 
Returning integer rarely makes sense in a microservices/API environment. It doesn't carry enough information.
and 
2.2 throwing InvalidOperationException.
Rather than returning exception and exposing our application details (stack trace!) I would return an object similar to:
{ 
  result = null, 
  exception { 
			  id // for searching 
			  type/code/status // indicates seriousness of the error. Could be used for reports etc.
			  timestamp = "2020-02-04T08:49..",
		      message = "Unsupported product type"
			  }}
As a side note, ISelectInvoiceService wasn't using this "return (result.Success) ? result.ApplicationId ?? -1 : -1;" approach while other services were so it totally didn't make sense ;) (no consistency as how to handle the result)

3. no DI, obvious reasons - some classes should to be singletons (store for example) while lifetime of some would be `per request`.

4. It's a pity we have no control over SlothEnterprise.External as all services under V1 are practically begging to be derived from a common interface e.g. IApplicationSubmittable. Implementing the strategy pattern would be a little easier in such case.

Also, as you can see, I found that it didn't make sense to test anything but the Dispatcher mechanism.

That's probably all I could think of :-)
Thanks for the exercise. Looking forward to hear your assessment.

Regards,
andy





