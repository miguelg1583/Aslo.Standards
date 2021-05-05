using System;
using Outputs.Responses;

namespace Outputs.Outputs
{
    public class ValidationModelResult<T> : ValidationResult
    {
        public T Model { get; set; }

        public override BaseResponse ConvertToResponse(TimeSpan ts)
        {
            var baseRes =  base.ConvertToResponse(ts);
            return new BaseModelResponse<T>(baseRes, Model);
        }
    }
}