using Outputs.Responses;

namespace Outputs.Outputs
{
    public class ValidationModelResult<T> : ValidationResult
    {
        public T Model { get; set; }

        public override BaseResponse ConvertToResponse()
        {
            var baseRes =  base.ConvertToResponse();
            return new BaseModelResponse<T>(baseRes, Model);
        }
    }
}