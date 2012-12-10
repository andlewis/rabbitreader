using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace RabbitReader.Model
{
    [DebuggerDisplay("Status: {Status}")]
    public class OperationStatus
    {
        public static OperationStatus CreateFromException(string message, Exception exception)
        {
            var op = new OperationStatus()
            {
                Status = false,
                Message = message,
                OperationID = null

            };

            if (exception != null)
            {
                op.ExceptionMessage = exception.Message;
                op.ExceptionStackTrace = exception.StackTrace;

                if (exception.InnerException != null)
                {
                    op.ExceptionInnerMessage = exception.InnerException.Message;
                    op.ExceptionInnerStackTrace = exception.InnerException.StackTrace;
                }
            }

            return op;
        }

        public bool Status { get; set; }
        public int RecordsAffected { get; set; }
        public string Message { get; set; }
        public object OperationID { get; set; }

        public string ExceptionMessage { get; set; }
        public string ExceptionStackTrace { get; set; }
        public string ExceptionInnerMessage { get; set; }
        public string ExceptionInnerStackTrace { get; set; }
    }
}
