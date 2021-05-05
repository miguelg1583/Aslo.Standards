namespace Outputs.Responses
{
    public class BaseModelResponse<T> : BaseResponse
    {
        public T Model { get; set; }
    }
}