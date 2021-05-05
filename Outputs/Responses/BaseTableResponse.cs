using System.Collections.Generic;

namespace Outputs.Responses
{
    public class BaseTableResponse<T> : BaseResponse
    {
        public List<T> TableData { get; set; } = new List<T>();
        public object Totals { get; set; }
    }
}