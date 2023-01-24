using app.Dto;
using app.Validation;
using FluentValidation;

namespace app.Service
{
    public class OperationService : IOperationService
    {
        private readonly ILogger<OperationRequest> _logger;

        public OperationService(ILogger<OperationRequest> logger)
        {
            _logger = logger;
        }

        public OperationResponse Calculate(OperationRequest Request)
        {
            Func<decimal, decimal, string, decimal> peformCalculation = PeformCalculation;
            Func<decimal, string, OperationResponse> returnResp = (res, mess) => new OperationResponse() { Result = res, Message = mess };
            Action<OperationRequest> validateRequest = (Request) =>
            {
                var validator = new OperationValidator();
                validator.Validate(Request, options => options.ThrowOnFailures());
            };

            return Task.Run(() =>
            {
                try
                {
                    validateRequest.Invoke(Request);
                    return returnResp.Invoke(peformCalculation.Invoke(Request.Parameter1, Request.Parameter2, Request.Operation!), "OK");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    return returnResp.Invoke(0, ex.Message);
                }
            }).Result;
        }

        private decimal PeformCalculation(decimal p1, decimal p2, string op)
        {
            switch (op)
            {
                case "+": return p1 + p2;
                case "-": return p1 - p2;
                case "*": return p1 * p2;
                case "/": return p1 / p2;
                default: throw new InvalidOperationException("Invalid operation");
            }
        }
    }
}