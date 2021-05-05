using System;
using Aslo.Standards.Outputs.Extensions;

namespace Aslo.Standards.Outputs.Items
{
    public abstract class Validation : IEquatable<Validation>
    {
        #region Members
        public int Code { get; }
        public string Message { get; }
        public string TraceMessage { get; }

        #endregion

        #region Constructor

        protected Validation(int code, string message)
        {
            Code = code;
            Message = message;
        }

        protected Validation(int code, string message, string traceMessage)
        {
            Code = code;
            Message = (message ?? string.Empty).Trim();
            TraceMessage = (traceMessage ?? string.Empty).Trim();
        }

        #endregion

        public override string ToString()
        {
            return Code == 0 ? Message : $"({Code.GetLowWord():D3}).({Code.GetHighWord()}) {Message}";
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