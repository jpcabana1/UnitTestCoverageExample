using app.Dto;

namespace app.test.Models
{
    public class OperationModel
    {
        public OperationRequest? Operation { get; set; }
        public decimal ExpectedResult { get; set; }
    }
}