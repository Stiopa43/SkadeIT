using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class CSNotFoundException : CSBaseException
    {
        public CSNotFoundException(string message, bool ifShowResponseMessage = true)
            : base(404, message, message, ifShowResponseMessage)
        {
        }

        public CSNotFoundException(string internalMessage, string responseMessage, bool ifShowResponseMessage = true)
            : base(404, internalMessage, responseMessage, ifShowResponseMessage)
        {
        }

        public CSNotFoundException(Type entityType, string entityId, bool ifShowResponseMessage = true)
            : base(404, $"Entity of type '{entityType.Name}', with Id '{entityId}' was not found.", "Requested data was not found.", ifShowResponseMessage)
        {
        }

        public CSNotFoundException(Type entityType, string entityId, string responseMessage, bool ifShowResponseMessage = true)
            : base(404, $"Entity of type '{entityType.Name}', with Id '{entityId}' was not found.", responseMessage, ifShowResponseMessage)
        {
        }
    }
}
