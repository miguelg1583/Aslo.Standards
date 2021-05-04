using System;
using Outputs.Extensions;

namespace Outputs
{
    public sealed class Validation : IEquatable<Validation>
    {
        #region Members

        private int Code { get; }
        private string Message { get; }
        private string TraceMessage { get; }

        #endregion

        #region Constructor

        private Validation(int code, string message)
        {
            Code = code;
            Message = message;
        }

        private Validation(int code, string message, string traceMessage)
        {
            Code = code;
            Message = (message ?? string.Empty).Trim();
            TraceMessage = (traceMessage ?? string.Empty).Trim();
        }

        #endregion

        public override string ToString()
        {
            if (Code == 0)
                return Message;

            return $"({Code.GetLowWord():D3}).({Code.GetHighWord()}) {Message}";
        }

        #region IEquatable Members

        public bool Equals(Validation other)
        {
            if (other != null)
                return other.Code == Code && other.Message == Message;
            return false;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Validation) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Code, Message, TraceMessage);
        }

        #endregion
    }
}