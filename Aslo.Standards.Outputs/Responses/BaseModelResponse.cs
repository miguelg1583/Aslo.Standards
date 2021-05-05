namespace Aslo.Standards.Outputs.Responses
{
    public class BaseModelResponse<T> : BaseResponse
    {
        public BaseModelResponse(BaseResponse baseRes, T model)
        {
            ElapsedTime = baseRes.ElapsedTime;
            Timestamp = baseRes.Timestamp;
            ErrorCodes = baseRes.ErrorCodes;
            Errors = baseRes.Errors;
            Warnings = baseRes.Warnings;
            Messages = baseRes.Messages;
            Model = model;
        }

        public T Model { get; set; }
    }
}