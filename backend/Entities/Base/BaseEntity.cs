using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Base
{
    public abstract class BaseEntity
    {
        public bool IsDeleted { get; set; }
        public bool IsArchieved { get; set; }
        public DateTime CreatedDateUtc { get; set; } = DateTime.UtcNow;
        public DateTime? LastModifiedDateUtc { get; set; } = null;

    }
}
