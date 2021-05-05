namespace Outputs.Outputs
{
    public class ValidationModelResult<T> : ValidationResult
    {
        public T Model { get; set; }
    }
}