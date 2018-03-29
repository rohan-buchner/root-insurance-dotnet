using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NSubstitute;
using NSubstitute.Extensions;
using RootSDK;
using RootSDK.Core;
using RootSDK.Insurance;
using RootSDK.Insurance.Models;
using RootSDK.Insurance.Services;
using Xunit;

namespace Tests
{
    public class InsuranceTests
    {
        [Fact]
        public async Task ListGadgetModelsShouldRetunAListOfGadgetModels()
        {
            // Arrange
            var mockInsuranceClient= Substitute.For<IRootInsuranceClient>();
            var mockQuoteService= Substitute.For<IQuoteService>();
            
            var testClass = new RootClient(mockInsuranceClient);
            
            mockInsuranceClient.ReturnsForAll(mockQuoteService);
            
            var taskResponse= Substitute.For<IList<Gadget>>();
            
            mockQuoteService.ReturnsForAll(taskResponse);
            
            // Act
            var gadgets = await testClass.Insurance.Quotes.ListGadgetModels();
            
            // Assert
            Assert.Equal(taskResponse, gadgets);
        }
        
        [Fact]
        public async Task CreateGadgetQuoteShouldReturnAQuoteItemOfTypeGadget()
        {
            // Arrange
            var apiMock = Substitute.For<IRootApiClient>();
            var taskResponse= Substitute.For<QuoteItem<Gadget>>();
            apiMock.ReturnsForAll(taskResponse);
            
            var testClass = new QuoteService(apiMock);
            
            // foo = Act
            var foo = await testClass.CreateGadgetQuote(It.IsAny<object>());
            
            // Assert
            Assert.Equal(taskResponse, foo);
        }
    }
}