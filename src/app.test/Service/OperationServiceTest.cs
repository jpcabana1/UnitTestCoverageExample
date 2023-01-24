using app.Dto;
using app.Service;
using app.test.Models;
using app.test.Stubs;
using Microsoft.Extensions.Logging;
using Moq;
using System.Reflection;

namespace app.test.Service
{
    public class OperationServiceTest
    {

        [Theory]
        [ClassData(typeof(OperationData))]
        public void Calculate_ThereAreValidOperations_ThenReturnSucess(OperationModel data)
        {
            //Arrange
            var mockLogger = new Mock<ILogger<OperationRequest>>();
            var service = new OperationService(mockLogger.Object);

            //Act

            var result = service.Calculate(data.Operation!);

            //Assert
            Assert.Equal(data.ExpectedResult, result.Result);

        }

        [Fact]
        public void Calculate_IsInvalidOperation_ThenThrowsExceptions()
        {
            //Arrange
            var operation = new OperationRequest() { Parameter1 = 2, Parameter2 = 2, Operation = "error" };
            var mockLogger = new Mock<ILogger<OperationRequest>>();
            var service = new OperationService(mockLogger.Object);

            //Act
            var result = service.Calculate(operation);

            //Assert
            Assert.NotEqual("Ok", result.Message!);
        }

        [Fact]
        public void PeformCalculation_WhenSwitchCaseDefault_ThenThrowsException()
        {
            //Arrange
            var value = "2.0";
            var mockLogger = new Mock<ILogger<OperationRequest>>();
            var service = new OperationService(mockLogger.Object);
            var method = service.GetType().GetMethod("PeformCalculation", BindingFlags.Instance | BindingFlags.NonPublic)!;
            object[] pars = { decimal.Parse(value), decimal.Parse(value), "error" };

            //Act + Assert
            Assert.Throws<TargetInvocationException>(() => method.Invoke(service, pars));
        }
    }
}