using app.Dto;

namespace app.Service
{
    public interface IOperationService
    {
        OperationResponse Calculate(OperationRequest Request);
    }
}