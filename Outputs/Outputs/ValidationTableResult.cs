using System.Collections.Generic;
using Outputs.Responses;

namespace Outputs.Outputs
{
    public class ValidationTableResult<T> : ValidationResult
    {
        public List<T> TableData { get; set; } = new List<T>();
        public object Totals { get; set; }

        public override BaseResponse ConvertToResponse()
        {
            var baseRes =  base.ConvertToResponse();
            return new BaseTableResponse<T>(baseRes, TableData, Totals);
        }
    }
}