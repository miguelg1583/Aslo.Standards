using System;
using System.Text;

namespace Outputs.Extensions
{
    public static class ExceptionHelper
    {
        public static string ToLogString(this Exception err)
        {
            var sb = new StringBuilder();
            // var err = exception;
            while (err != null)
            {
                sb.AppendLine("[" + err.GetType() + "] " + err.Message);
                sb.AppendLine(err.StackTrace);
                sb.AppendLine("----------------------------------------------------");
                err = err.InnerException;
            }

            return sb.ToString();
        }
    }
}