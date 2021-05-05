namespace Outputs.Items
{
    public class ValidationError : Validation
    {
        #region Constructor

        public ValidationError(int code, string errorMessage) : base(code, errorMessage) { }

        public ValidationError(int code, string errorMessage, string traceMessage) : base(code, errorMessage, traceMessage) { }

        #endregion
    }
}