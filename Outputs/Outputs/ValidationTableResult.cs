using System.Collections.Generic;

namespace Outputs.Outputs
{
    public class ValidationTableResult<T> : ValidationResult
    {
        public List<T> TableData { get; set; } = new List<T>();
    }
}