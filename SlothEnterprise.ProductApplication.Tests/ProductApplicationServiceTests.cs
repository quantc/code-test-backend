using FluentAssertions;
using Moq;
using NUnit.Framework;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.ProductHandling;
using SlothEnterprise.ProductApplication.ProductHandling.Handlers;
using SlothEnterprise.ProductApplication.Products;
using System;
using SlothEnterprise.ProductApplication.Tests.Stubs;

namespace SlothEnterprise.ProductApplication.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(typeof(SelectiveInvoiceDiscount), typeof(SelectiveInvoiceDiscountHandler))]
        [TestCase(typeof(ConfidentialInvoiceDiscount), typeof(ConfidentialInvoiceDiscountHandler))]
        [TestCase(typeof(BusinessLoans), typeof(BusinessLoansHandler))]
        [TestCase(typeof(UnsupportedProductTypeStub), typeof(UnsupportedProductHandler))]
        public void When_ApplicationProductIsProvided_Then_CorrectServiceHandlerIsUsed(Type productType,
            Type handlerType)
        {
            var selectInvoiceServiceMock = new Mock<ISelectInvoiceService>();
            var confidentialInvoiceWebServiceMock = new Mock<IConfidentialInvoiceService>();
            var businessLoansServiceMock = new Mock<IBusinessLoansService>();
            var handlerStoreMock = new ProductHandlerStore(
                selectInvoiceServiceMock.Object,
                confidentialInvoiceWebServiceMock.Object,
                businessLoansServiceMock.Object);
            var product = (IProduct)Activator.CreateInstance(productType);

            var sut = new ProductHandlerDispatcher(handlerStoreMock); //system under test
            var handler = sut.GetHandler(product);

            handler.Should().BeOfType(handlerType);
        }
    }
}