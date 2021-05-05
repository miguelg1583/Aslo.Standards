using System.Collections.Generic;

namespace Aslo.Standards.Outputs.Responses
{
    public class BaseTableResponse<T> : BaseResponse
    {
        public BaseTableResponse(BaseResponse baseRes, List<T> tableData, object totals)
        {
            ElapsedTime = baseRes.ElapsedTime;
            Timestamp = baseRes.Timestamp;
            ErrorCodes = baseRes.ErrorCodes;
            Errors = baseRes.Errors;
            Warnings = baseRes.Warnings;
            Messages = baseRes.Messages;
            TableData = tableData;
            Totals = totals;
        }

        public List<T> TableData { get; set; } = new List<T>();
        public object Totals { get; set; }
    }
}