using System;
using System.Collections.Generic;

namespace Outputs.Responses
{
    public class BaseResponse
    {
        public TimeSpan ElapsedTime { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public List<int> ErrorCodes { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public List<string> Warnings { get; set; } = new List<string>();
        public List<string> Messages { get; set; } = new List<string>();
        public bool HasErrors => Errors.Count > 0;
        public bool HasWarnings => Warnings.Count > 0;
        public bool IsEmpty => Warnings.Count == 0 && Errors.Count == 0;
    }
}