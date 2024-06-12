using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class CSBadRequestException : CSBaseException
    {
        public CSBadRequestException(string message, bool ifShowResponseMessage = true)
            : base(400, message, message, ifShowResponseMessage)
        {
        }

        public CSBadRequestException(string internalMessage, string responseMessage, bool ifShowResponseMessage = true)
            : base(400, internalMessage, responseMessage, ifShowResponseMessage)
        {
        }

        public CSBadRequestException(IDictionary<string, string> errors, bool ifShowResponseMessage = true)
            : base(400, errors, ifShowResponseMessage)
        {
        }
    }
}
