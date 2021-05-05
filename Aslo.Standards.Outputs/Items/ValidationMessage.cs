namespace Aslo.Standards.Outputs.Items
{
    public class ValidationMessage : Validation
    {
        public ValidationMessage(int code, string message) : base(code, message)
        {
        }

        public ValidationMessage(int code, string message, string traceMessage) : base(code, message, traceMessage)
        {
        }
    }
}