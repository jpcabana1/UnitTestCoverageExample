using app.Service;
using app.test.Models;
using app.test.Stubs;
using Microsoft.Extensions.Logging;
using Moq;

namespace app.test.Service;

public class OperationServiceTest
{

    [Theory]
    [ClassData(typeof(OperationData))]
    public void Calculate_ThereAreValidOperations_ThenReturnSucess (OperationModel data) {
        //Arrange
        var mockLogger = new Mock<ILogger<OperationRequest>>();
        var service = new OperationService (mockLogger.Object);

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

}
