using app.test.Models;

namespace app.test.Stubs;

public class OperationData : TheoryData<OperationModel>
{
    public OperationData()
    {
        Add(new OperationModel()
        {
            Operation = new OperationRequest() { Parameter1 = 2, Parameter2 = 2, Operation = "+" },
            ExpectedResult = 4
        });
        Add(new OperationModel()
        {
            Operation = new OperationRequest() { Parameter1 = 2, Parameter2 = 2, Operation = "-" },
            ExpectedResult = 0
        });
        Add(new OperationModel()
        {
            Operation = new OperationRequest() { Parameter1 = 2, Parameter2 = 2, Operation = "*" },
            ExpectedResult = 4
        });
        Add(new OperationModel()
        {
            Operation = new OperationRequest() { Parameter1 = 2, Parameter2 = 2, Operation = "/" },
            ExpectedResult = 1
        });
    }
}
